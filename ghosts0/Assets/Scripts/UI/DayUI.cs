using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayUI : MonoBehaviour
{
    public static DayUI dayUI;
    void Awake() {dayUI = this;}
    public GameObject player;
    public CharacterMovement CHM;
    public Animator nextNightAnim;
    public GameObject nextNightPanel;

    void Start()
    {
        CHM = player.GetComponent<CharacterMovement>();
    }

    public void confirmNextNight()
    {
        CHM.enabled = !enabled;
        nextNightPanel.SetActive(true);
        nextNightAnim.SetTrigger("Start");

    }

    public void nextNight()
    {
        nextNightPanel.SetActive(false);
        GameManager.Instance.UpdateGameState(GameState.Night);
        CHM.enabled = enabled;
    }
}
