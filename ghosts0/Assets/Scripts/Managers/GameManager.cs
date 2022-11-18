using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static DayUI;
using static StatManager;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public GameObject dayCanvas;
    public GameObject nightCanvas;
    public GameObject nightButton;

    public static event Action<GameState> OnGameStateChanged;

    public bool FirstTime = true;
    public float FirstTimeTimer;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Day);
        
        if(FirstTime)
            StartCoroutine("firstTime");
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Day:
                HandleDay();
                break;
            case GameState.Night:
                HandleNight();
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleDay()
    {
        for (int i = 0; i < GhostManager.instance.allGhosts.Count; i++)
        {
            GhostManager.instance.allGhosts[i].HandleDayPreparations(); 
            GhostManager.instance.allGhosts[i].gHealth += 20;
        } 
        PlayerLevels.instance.Health += 20;
        GhostManager.instance.HandleGhostProd();
        GhostDetection.instance.CloseGhostUI();
        nightButton.SetActive(true);
        dayCanvas.SetActive(true);
        nightCanvas.SetActive(false);
    }

    private void HandleNight()
    {
        for (int i = 0; i < GhostManager.instance.allGhosts.Count; i++) GhostManager.instance.allGhosts[i].HandleEveningStats();
        DayNightCycle.instance.HandleNightLight();
        GhostDetection.instance.CloseGhostUI();
        nightButton.SetActive(false);
        dayCanvas.SetActive(false);
        nightCanvas.SetActive(true);
        Teleport.instance.PortOut();
    }

    public IEnumerator firstTime()
    {
        yield return new WaitForSeconds(3);
        FirstTime = false;
        yield return null;
    }
}

public enum GameState
{
    Start,
    Day,
    Night,

}
