using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EctoMilk : MonoBehaviour
{
    public static EctoMilk instance;
    void Awake(){instance = this;}

    public float ProductionRate;
    public int GhostCapacity;

    Ghost milkedGhost;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ghost"))
        {
            milkedGhost = other.GetComponent<Ghost>();
            GhostManager.instance.freeGhosts.Remove(milkedGhost);
            GhostManager.instance.milkingGosts.Add(milkedGhost);
            milkedGhost.DisableBools();
            milkedGhost.gMilking = true;
            print("Ghost milking: " + milkedGhost.gID);
        }
    }

}
