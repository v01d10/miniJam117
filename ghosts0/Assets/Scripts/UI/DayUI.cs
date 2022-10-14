using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static StatManager;

public class DayUI : MonoBehaviour
{
    public static DayUI dayUI;
    void Awake() {dayUI = this;}
    public GameObject player;
    public CharacterMovement CHM;
    public Animator nextNightAnim;
    public GameObject nextNightPanel;
    public TextMeshProUGUI NightNumber;

    void Start()
    {
        CHM = player.GetComponent<CharacterMovement>();
    }

    public void AnnounceNight()
    {
        nextNightPanel.SetActive(true);
        nextNightAnim.SetTrigger("Start");
        NightNumber.text = StatManager.instance.survivedNights.ToString();
    }

    public void nextNight()
    {
        nextNightPanel.SetActive(false);
        GameManager.Instance.UpdateGameState(GameState.Night);
        CHM.enabled = enabled;
    }
}
