using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light dirLight;

    public Color nightColorSky;
    public Color nightColorEquator;
    public Color nightColorGround;

    void Update()
    {
        if(GameManager.Instance.State == GameState.Day && LevelLoader.instance.outside)
        {
            HandleDayLight();
        }

        if(GameManager.Instance.State == GameState.Night || !LevelLoader.instance.outside)
        {
            HandleNightLight();

        }
    }

    void HandleDayLight()
    {
        dirLight.intensity = Mathf.Lerp(0.3f, 1f, 6f);
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;

    }

    void HandleNightLight()
    {
        dirLight.intensity = Mathf.Lerp(1f, 0.3f, 6f);
        // RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
        // RenderSettings.ambientSkyColor = nightColorSky;
        // RenderSettings.ambientEquatorColor = nightColorEquator;
        // RenderSettings.ambientGroundColor = nightColorGround;
    }
}
