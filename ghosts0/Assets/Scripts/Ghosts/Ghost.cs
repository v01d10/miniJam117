using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static GhostManager;

public class Ghost : MonoBehaviour
{
    public static Ghost instance;
    void Awake() {instance = this;}
    public NavMeshAgent gAgent;
    public bool gFollow;

    [Header("Base Stats")]
    public int gID;

    public float gHealth;
    public float gMaxHealth;
    public float gStrength;
    public float gStrengthExp;
    public float gStrengthExpNeeded = 1500;
    public float gScarinnes;
    public float gScarinnesExp;
    public float gScarinessExpNeeded = 1500;

    [Header("Needs")]
    public float gHappiness = 50;
    public float gMaxHappines = 100;
    public float gEctoplasmLevel = 20;
    public float gMaxEctoplasmLevel = 100;
    public float gEctoplasmToGive;

    public bool gFed;
    public bool gLeaving;
    public bool gFree = true;
    public bool gSleeping;
    public bool gMilking;
    public bool gWorking;

    [Header("Night")]
    public Vector3 LastDayPosition;
    bool PreparedForNight;
    bool followPlayer;
    public Transform Target;
    public Enemy TargetEnemy;

    [Header("Other")]
    public float gKilled;

    void Start()
    {
        gMaxHealth = 100 + (gStrength * 10);
        gHealth = gMaxHealth;
        gScarinnes = Random.Range(1, 6);
        gStrength = Random.Range(1, 6);
        gEctoplasmLevel = Random.Range(20, 50);
        gEctoplasmToGive = (gScarinnes + gStrength) / 2;
        gHappiness = Random.Range(20, 50);

        gAgent = GetComponent<NavMeshAgent>();
        GhostManager.instance.allGhosts.Add(this);
        GhostManager.instance.freeGhosts.Add(this);
        GhostNav.instance.GoToPoint(gAgent);
    }
    void Update()
    {
        if (GameManager.Instance.State == GameState.Night && gFree)
        {
            if (!PreparedForNight)
                HandleNightPreparations();
            else
            {
                if (Target != null)
                    gAgent.SetDestination(Target.position);
                else
                {
                    Target = GhostCarrying.instance.Player;
                    gAgent.SetDestination(Target.position);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (Target = Teleport.instance.Player.transform)
            {
                TargetEnemy = other.GetComponent<Enemy>();
                Target = other.transform;
                StartCoroutine("Attack");
            }
        }
    }

    void HandleEctoplasm()
    {
        if (gEctoplasmLevel <= 100)
            gEctoplasmLevel += gEctoplasmToGive;
        else
        {
            gHappiness = 0;
        }
    }

    public void HandleDayPreparations()
    {
        if (LastDayPosition != null)
            transform.position = LastDayPosition;
    }

    public void HandleEveningStats()
    {
        //if(!gFed && gHappiness > 0) gHappiness -= Random.Range(5, 15);
        if (!gSleeping && gHappiness > 0) gHappiness -= Random.Range(5, 10);
        if (gWorking && gHappiness > 0) gHappiness -= Random.Range(10, 16);
        if (gSleeping && gHappiness < gMaxHappines) gHappiness += Random.Range(5, 13);
        if (gFree && gHappiness < gMaxHappines) gHappiness += Random.Range(5, 13);
        if (gMilking && gHappiness < gMaxHappines) gHappiness += Random.Range(10, 13);
    }

    public void HandleNightPreparations()
    {
        LastDayPosition = transform.position;
        Target = Teleport.instance.Player.transform;
        gAgent.enabled = !enabled;
        transform.position = Target.position;
        gAgent.enabled = enabled;
        PreparedForNight = true;
    }

    public IEnumerator Attack()
    {
        if (TargetEnemy.EnemyHealth > gStrength)
        {
            if (TargetEnemy != null)
            {
                print("Ghost: " + gID + " Attacked enemy");
                TargetEnemy.EnemyHealth -= gStrength;
                yield return new WaitForSeconds(1.5f);
                StartCoroutine("Attack");
            }
        }
        else
        {
            if (TargetEnemy != null)
            {
                print("Ghost: " + gID + " Killed enemy");

                if (gStrengthExp < gStrengthExpNeeded)
                    gStrengthExp += TargetEnemy.ExpToGive;
                else
                {
                    gStrength++;
                    gStrengthExp = 0;
                    gStrengthExpNeeded *= 1.5f;
                }
                ResourceManager.instance.Money += TargetEnemy.MoneyToGive;
                gKilled++;
                Target = Teleport.instance.Player.transform;
                TargetEnemy.Death();
                yield return null;
            }
        }
    }

    public void DisableBools()
    {
        gFree = false;
        gSleeping = false;
        gMilking = false;
        gWorking = false;
    }

    public void gDeath()
    {
        Destroy(gameObject);
        GhostManager.instance.allGhosts.Remove(this);
        GhostManager.instance.milkingGosts.Remove(this);
        GhostManager.instance.workingGhosts.Remove(this);
        GhostManager.instance.sleepingGhosts.Remove(this);
        GhostManager.instance.freeGhosts.Remove(this);
        GhostManager.instance.HandleGhostID();
    }

}
