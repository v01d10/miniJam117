using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static string directory = "/SaveData/";
    public static string pFileName = "Data.save";

    public static void SavePlayer(PlayerData PD)
    {
        string dir = Application.persistentDataPath + directory;

        PD.SavePlayerData(PlayerLevels.instance, ResourceManager.instance, StatManager.instance, EnemySpawner.instance);

        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
            Debug.Log("Dir created");
        }

        string json = JsonUtility.ToJson(PD);
        File.WriteAllText(dir + pFileName, json);
        Debug.Log("Saved" + json);
    }

    public static void SaveGhost()
    {
        string dir = Application.persistentDataPath + directory;
        string json = JsonUtility.ToJson(GhostManager.instance.allGhosts);

        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
            Debug.Log("Dir created");
        }

        File.WriteAllText(dir + directory, json);
    }

    public static PlayerData LoadPlayer()
    {
        string fullPath = Application.persistentDataPath + directory + pFileName;
        PlayerData PD = new PlayerData();

        if(File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            PD = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Loaded" + json);
        }
        else
        {
            Debug.Log("Save file does not exist");
        }

        return PD;
    }
}
