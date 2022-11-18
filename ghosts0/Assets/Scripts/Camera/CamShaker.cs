using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class CamShaker : MonoBehaviour
{
    public static CamShaker instance;
    void Awake(){instance = this;}

    public ShakeData shotShake;
    public ShakeData spawnShake;

    public void ShotShake()
    {
        CameraShakerHandler.Shake(shotShake);
    }

    public void SpawnShake()
    {
        CameraShakerHandler.Shake(spawnShake);
    }
}
