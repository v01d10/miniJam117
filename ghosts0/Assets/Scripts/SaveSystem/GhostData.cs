using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GhostData
{
    public List<Ghost> Ghosts;
    public float GhostHealth;
    public float GhostMaxHealth;
    public float GhostStrength;
    public float GhostStrengthExp;
    public float GhostStrengthExpNeeded;
    public float GhostScariness;
    public float GhostScarinessExp;
    public float GhostScarinessExpNeeded;

    public float GhostHappiness;
    public float GhostMaxHappiness;
    public float GhostEctoplasmLevel;
    public float GhostMaxEctoplasmLevel;
    public float GhostEctoplasmToGive;

    public float[] GhostPosition;

    public bool GhostFed;
    public bool GhostLeaving;
    public bool GhostFree;
    public bool GhostSleeping;
    public bool GhostMilking;
    public bool GhostWorking;
    

    public void SaveGhostData(Ghost ghost)
    {
        Ghosts = GhostManager.instance.allGhosts;

        for (int i = 0; i < Ghosts.Count; i++)
        {
            GhostData gData = new GhostData();

            gData.GhostHealth = Ghosts[i].gHealth;
            gData.GhostMaxHealth = Ghosts[i].gMaxHealth;
            gData.GhostStrength = Ghosts[i].gStrength;
            gData.GhostStrengthExp = Ghosts[i].gStrengthExp;
            gData.GhostStrengthExpNeeded = Ghosts[i].gStrengthExpNeeded;
            gData.GhostScariness = Ghosts[i].gScarinnes;
            gData.GhostScarinessExp = Ghosts[i].gScarinnesExp;
            gData.GhostScarinessExpNeeded = Ghosts[i].gScarinessExpNeeded;

            gData.GhostHappiness = Ghosts[i].gHappiness;
            gData.GhostHappiness = Ghosts[i].gMaxHappines;
            gData.GhostEctoplasmLevel = Ghosts[i].gEctoplasmLevel;
            gData.GhostMaxEctoplasmLevel = Ghosts[i].gMaxEctoplasmLevel;
            gData.GhostEctoplasmToGive = Ghosts[i].gEctoplasmToGive;

            Vector3 GhostPos = Ghosts[i].transform.position;
            gData.GhostPosition = new float[]
            {
                GhostPos.x, GhostPos.y, GhostPos.z
            };

            gData.GhostFed = ghost.gFed;
            gData.GhostLeaving = ghost.gLeaving;
            gData.GhostFree = ghost.gFree;
            gData.GhostSleeping = ghost.gSleeping;
            gData.GhostMilking = ghost.gMilking;
            gData.GhostMilking = ghost.gWorking;
            
        }
    }
    
}
