using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFac : MonoBehaviour
{
    public static BulletFac instance;
    void Awake(){instance = this;}

    public float ProductionRate;
    public int GhostCapacity;

    Ghost workingGhost;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ghost"))
        {
            workingGhost = other.GetComponent<Ghost>();
            GhostManager.instance.freeGhosts.Remove(workingGhost);
            GhostManager.instance.workingGhosts.Add(workingGhost);
            workingGhost.DisableBools();
            workingGhost.gWorking = true;
            print("Ghost working: " + workingGhost.gID);
        }
    }

}
