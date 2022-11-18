using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GhostBaner : MonoBehaviour
{
    public int banerID;
    public TextMeshProUGUI gHp;
    public TextMeshProUGUI gScarLvl;
    public TextMeshProUGUI gStrLvl;

    bool InFreePanel;

    void Start()
    {
        Scareventures.instance.GhostButtons.Add(GetComponent<Button>());
    } 

    public void MoveGhostScare()
    {
        if(InFreePanel)
        {
            Ghost g = GhostManager.instance.allGhosts[banerID];
            g.gLeaving = true;
            GhostManager.instance.allGhosts.Remove(g);
            GhostManager.instance.leavingGosts.Add(g);
            transform.SetParent(Scareventures.instance.LeaveGhostsPanel);
            InFreePanel = false;
        }
        else
        {
            Ghost g = GhostManager.instance.allGhosts[banerID];
            g.gLeaving = false;
            GhostManager.instance.allGhosts.Add(g);
            GhostManager.instance.leavingGosts.Remove(g);
            transform.SetParent(Scareventures.instance.FreeGhostsPanel);
            InFreePanel = true;
        }
    }
}
