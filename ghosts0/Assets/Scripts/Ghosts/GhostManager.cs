using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public static GhostManager instance;
    void Awake() {instance = this;}

    public List<Ghost> allGhosts = new List<Ghost>();
    public List<Ghost> freeGhosts = new List<Ghost>();
    public List<Ghost> sleepingGhosts = new List<Ghost>();
    public List<Ghost> workingGhosts = new List<Ghost>();
    public List<Ghost> leavingGosts = new List<Ghost>();
    public List<Ghost> milkingGosts = new List<Ghost>();

    void Start()
    {
        Invoke("HandleGhostID", 1);
    }

    public void HandleGhostID()
    {
        for (int i = 0; i < allGhosts.Count; i++) allGhosts[i].gID = i;
    }

    public void HandleGhostProd()
    {
        for (int i = 0; i < milkingGosts.Count; i++)
        {
            milkingGosts[i].gEctoplasmLevel -= EctoMilk.instance.ProductionRate;
            ResourceManager.instance.Ectoplasm += milkingGosts[i].gEctoplasmToGive;
        }

        for (int i = 0; i < workingGhosts.Count; i++)
        {
            ResourceManager.instance.Ectoplasm -= BulletFac.instance.ProductionRate;
            ResourceManager.instance.Bullets += BulletFac.instance.ProductionRate;

        }
    }
}
