using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager saveM;
    public PlayerData PD;

    void Awake()
    {
        saveM = this;
        SaveSystem.LoadPlayer();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            SaveSystem.SavePlayer(PD);
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            PD = SaveSystem.LoadPlayer();
        }
    }

    void OnApplicationQuit()
    {
        SaveSystem.SavePlayer(PD);
    }

}
