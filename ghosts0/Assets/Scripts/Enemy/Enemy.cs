using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    public float EnemyHealth;
    public float EnemyDamage;

    public float ExpToGive;
    public float MoneyToGive;
    public int EnemyCost;
    public GameObject EnemyPrefab;
    public VisualEffect DeathSmoke;
    PlayerLevels Player;
    Ghost SelectedGhost;

[Header("Nav")]
    public NavMeshAgent EnemyAgent;
    public Transform Target;

    void Start()
    {
        EnemyAgent = GetComponent<NavMeshAgent>();
        ExpToGive = Random.Range(1, 5) * EnemyCost;
        MoneyToGive = Random.Range(0, 8) * EnemyCost;
        EnemySpawner.instance.EnemiesToKill.Add(this);
    }

    void Update()
    {
        if(Target != null)
            EnemyAgent.SetDestination(Target.position);
        else
            Target = Teleport.instance.Player.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Target = Teleport.instance.Player.transform)
            {
                Player = other.GetComponent<PlayerLevels>();
                Target = Player.transform;
                StartCoroutine("AttackPlayer");
            }
        }

        else if(other.CompareTag("Ghost"))
        {
            if(Target = Teleport.instance.Player.transform )
            {
                SelectedGhost = other.GetComponent<Ghost>();
                Target = other.transform;
                StartCoroutine("AttackGhost");
            }
        }

    }

    public IEnumerator AttackPlayer()
    {
        if(Player.Health >= EnemyDamage)
        {
            print("Attacked player");
            Player.Health -= EnemyDamage;
            yield return new WaitForSeconds(1.5f);
            StartCoroutine("AttackPlayer");
        }
        else
        {
            Player.PlayerDeath();
            yield return null;
        }
    }

    public IEnumerator AttackGhost()
    {
        if(SelectedGhost.gHealth >= EnemyDamage && SelectedGhost != null)
        {
            print("Attacked ghost: " + SelectedGhost.gID);
            SelectedGhost.gHealth -= EnemyDamage;
            yield return new WaitForSeconds(1.5f);
            StartCoroutine("AttackGhost");
        }
        else if(SelectedGhost.gHealth <= EnemyDamage && SelectedGhost != null )
        {
            SelectedGhost.gDeath();
            Target = Teleport.instance.Player.transform;
            yield return null;
        }
    }

    public void DecreaseHealth(float amount)
    {
        if(amount < EnemyHealth)
        {
            EnemyHealth -= amount;
        }
        else
        {
            EnemyHealth = 0;
            Death();
        }
    }

    public void Death()
    {
        DeathSmoke.Play();
        EnemySpawner.instance.EnemiesToKill.Remove(this);

        if(EnemySpawner.instance.EnemiesToKill.Count <= 0)
        {
            EnemySpawner.instance.FinishWave();
        }

        PlayerLevels.instance.Exp += ExpToGive;
        ResourceManager.instance.Money += MoneyToGive;

        Destroy(gameObject);
    }
}
