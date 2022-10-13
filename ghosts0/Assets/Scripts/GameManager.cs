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

    public float dayTimer;
    public float nightTimer;

    public GameObject dayCanvas;
    public GameObject nightCanvas;

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
        if(State == GameState.Day && dayTimer < 18)
        {
            dayTimer += Time.deltaTime;

            if(dayTimer >= 18)
            UpdateGameState(GameState.NextNight);
        }

        else if(State == GameState.Night && nightTimer < 18)
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
            case GameState.NextNight:
                HandleNextNight();
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleDay()
    {
        statManager.survivedNights++;
        dayTimer = 0;
        dayCanvas.SetActive(true);
        nightCanvas.SetActive(false);
    }

    private void HandleNight()
    {
        Ghost.instance.HandleEveningStats();
        nightTimer = 0;
        dayCanvas.SetActive(false);
        dayCanvas.SetActive(true);
    }

    private void HandleNextNight()
    {
        dayUI.confirmNextNight();
    }
}



public enum GameState
{
    Start,
    Day,
    NextNight,
    Night,

}
