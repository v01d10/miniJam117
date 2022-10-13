using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GhostManager;

public class Ghost : MonoBehaviour
{
    public static Ghost instance;
    void Awake() {instance = this;}

[Header("Base Stats")]
    public int gID;

    public int gStrength;
    public float gStrengthExp;
    public int gScarinnes;
    public float gScarinnesExp;

[Header("Needs")]
    public float gHappiness;
    public float gBoredom;
    public float gEctoplasmLevel;

    public bool gFed;
    public bool gFight;
    public bool gSleeping;
    
    void Start()
    {
        gManager.allGhosts.Add(this);
        gID = gManager.allGhosts.IndexOf(this);
    }

    public void HandleEveningStats()
    {
        if(!gFed) gHappiness -= 15;
        if(gSleeping) gHappiness += 10;
    }

}
