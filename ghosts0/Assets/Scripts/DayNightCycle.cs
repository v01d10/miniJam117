using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public static DayNightCycle instance;
    void Awake(){instance = this;}

    public Light dirLight;

    void Update()
    {
        if(GameManager.Instance.State == GameState.Day && LevelLoader.instance.outside)
        {
            HandleDayLight();
        }
        else
            HandleNightLight();

    }

    public void HandleDayLight()
    {
        dirLight.intensity = 0.3f;

    }

    public void HandleNightLight()
    {
        dirLight.intensity = 0;
    }
}
