using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static SaveManager;

public class PlayerLevels : MonoBehaviour
{
    public static PlayerLevels instance;
    void Awake() { instance = this;}

    public float Health;
    public float MaxHealth;
    public float Lvl;
    public float Exp;
    public float ExpNeeded;
    public float ExpPerc;

[Header("Attributes")]
    public float AtPoints;
    public float Endurance;
    public float Speed;
    public float Inteligence;

[Header("Texts")]
    public GameObject StatPanel;
    public bool StatPanelOpened;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI AtText;
    public TextMeshProUGUI EnduranceText;
    public TextMeshProUGUI SpeedText;
    public TextMeshProUGUI SomethingText;
    public Image ExpBar;

[Header("Death")]
    public GameObject DeathPanel;

    void Start()
    {
        if(!GameManager.Instance.FirstTime)
        {
            MaxHealth = saveM.PD.PlayerMaxHealth;
            Lvl = saveM.PD.PlayerLevel;
            Exp = saveM.PD.PlayerExp;
            ExpNeeded = saveM.PD.PlayerExpNeeded;
            AtPoints = saveM.PD.PlayerAtPoints;
            Endurance = saveM.PD.PlayerEndurance;
            Speed = saveM.PD.PlayerSpeed;
            Health = MaxHealth;
            
        }
    }

    void FixedUpdate()
    {
        if(Exp > ExpNeeded)
        {
            float expTrans = Exp - ExpNeeded;
            Lvl++;
            AtPoints++;
            Exp = 0 + expTrans;
            ExpNeeded *= 1.5f;
        }
    }

    public void OpenStatPanel()
    {
        if(!StatPanelOpened)
        {
            StatPanel.SetActive(true);
            StatPanelOpened = true;
            LoadText();
        }
        else 
        {
            StatPanel.SetActive(false);
            StatPanelOpened = false;           
        }
        
    }

    public void LoadText()
    {
        HealthText.text = Health.ToString();
        MoneyText.text = ResourceManager.instance.Money.ToString();
        LevelText.text = Lvl.ToString();
        AtText.text = AtPoints.ToString();
        EnduranceText.text = Endurance.ToString();
        SpeedText.text = Speed.ToString();

        ExpPerc = Exp / ExpNeeded;
        ExpBar.fillAmount = ExpPerc;
    }

    public void IncreaseEndurance()
    {
        if(AtPoints >= 1)
        {
            Endurance++;
            AtPoints--;
            MaxHealth += 50;
            Health = MaxHealth;
        }
    }

    public void IncreaseSpeed()
    {
        if(AtPoints >= 1)
        {
            Speed++;
            AtPoints--;
            CharacterMovement.instance.speed += 0.01f;
        }
    }

    public void PlayerDeath()
    {
        DeathPanel.SetActive(true);
    }

    public void Respawn()
    {

        for (int i = 0; i < GhostManager.instance.allGhosts.Count; i++)
        {
            GhostManager.instance.allGhosts[i].gDeath();
        }

        for (int i = 0; i < EnemySpawner.instance.EnemiesToKill.Count; i++)
        {
            EnemySpawner.instance.EnemiesToKill[i].Death();
        }

        GameManager.Instance.UpdateGameState(GameState.Day);
        DeathPanel.SetActive(false);

        ResourceManager.instance.Money = 500;
        ResourceManager.instance.Ectoplasm = 0;
        ResourceManager.instance.Bullets = 200;

        StatManager.instance.enemiesKilled = 0;
        StatManager.instance.survivedNights = 0;

        EnemySpawner.instance.currWave = 0;

        transform.position = Teleport.instance.Basement.position;
        Health = MaxHealth;

        for (int i = 0; i < 3; i++) GhostAltar.instance.SummonGhost();

    }

    public void Quit()
    {
        Application.Quit();
    }
}
