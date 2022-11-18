using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static StatManager;

public class DayUI : MonoBehaviour
{
    public static DayUI instance;
    void Awake() {instance = this;}

    public GameObject player;
    public CharacterMovement CHM;
    public Animator nextNightAnim;
    public GameObject nextNightPanel;
    public TextMeshProUGUI NightNumber;

    public GameObject NightButton;
    public GameObject BuildButton;
    public GameObject StatButton;

    void Start()
    {
        CHM = player.GetComponent<CharacterMovement>();
    }

    public void Scareventure()
    {
        if(GhostManager.instance.allGhosts.Count > 0)
            Scareventures.instance.OpenScareventurePanel();
    }

    public void nextNight()
    {
        nextNightPanel.SetActive(false);
        GameManager.Instance.UpdateGameState(GameState.Night);
        CHM.enabled = enabled;
        AnnounceNight();
        EnemySpawner.instance.GenerateWave();
    }

    public void NextNightConfirm()
    {

    }

    public void AnnounceNight()
    {
        nextNightPanel.SetActive(true);
        nextNightAnim.SetTrigger("Start");
        NightNumber.text = StatManager.instance.survivedNights.ToString();
    }


}
