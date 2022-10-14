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

    public float nightTimer;

    public GameObject dayCanvas;
    public GameObject nightCanvas;
    public GameObject nightButton;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Day);
    }
    
    void Update()
    {
        if(State == GameState.Night && nightTimer < 18)
        {
            nightTimer += Time.deltaTime;

            if(nightTimer >= 18)
            UpdateGameState(GameState.Day);
        }

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
        nightButton.SetActive(true);
        StatManager.instance.survivedNights++;
        dayCanvas.SetActive(true);
        nightCanvas.SetActive(false);
    }

    private void HandleNight()
    {
        Ghost.instance.HandleEveningStats();
        nightButton.SetActive(false);
        dayCanvas.SetActive(false);
        dayCanvas.SetActive(true);
        Teleport.instance.PortOut();
        dayUI.AnnounceNight();
        nightTimer = 0;
    }

}



public enum GameState
{
    Start,
    Day,
    NextNight,
    Night,

}
