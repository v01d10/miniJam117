using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scareventures : MonoBehaviour
{
    public static Scareventures instance;
    void Awake() {instance = this;}

    public GameObject ScareventurePanel;
    public bool ScareventurePanelOpened;

    public Transform FreeGhostsPanel;
    public Transform LeaveGhostsPanel;

    public List<Button> GhostButtons = new List<Button>();

    public GameObject ghostBaner;

    int gIndex = 0;

    public void OpenScareventurePanel()
    {
        if(!ScareventurePanelOpened)
        {
            ScareventurePanel.SetActive(true);
            ScareventurePanelOpened = true;

            DayUI.instance.NightButton.SetActive(false);
            DayUI.instance.BuildButton.SetActive(false);
            DayUI.instance.StatButton.SetActive(false);

            for (int i = 0; i < GhostManager.instance.allGhosts.Count; i++)
            {
                LoadBanerText();

                gIndex++;
            }
        }
        else
        {
            ScareventurePanel.SetActive(false);
            ScareventurePanelOpened = false;

            DayUI.instance.NightButton.SetActive(true);
            DayUI.instance.BuildButton.SetActive(true);
            DayUI.instance.StatButton.SetActive(true);           
        }
    }

    public void LoadBanerText()
    {
        GameObject gb = Instantiate(ghostBaner, FreeGhostsPanel);
        GhostBaner gBaner = gb.GetComponent<GhostBaner>();
        gBaner.banerID = GhostManager.instance.allGhosts[gIndex].gID;
        gBaner.gHp.text = GhostManager.instance.allGhosts[gIndex].gHealth.ToString();
        gBaner.gScarLvl.text = GhostManager.instance.allGhosts[gIndex].gScarinnes.ToString();
        gBaner.gStrLvl.text = GhostManager.instance.allGhosts[gIndex].gStrength.ToString();

        Button BanerButt = gBaner.GetComponent<Button>();
        BanerButt.onClick.AddListener(gBaner.MoveGhostScare);

    }

    public void ScareventureReturn()
    {
        for (int i = 0; i < GhostManager.instance.leavingGosts.Count; i++)
        {
            Ghost gReturning = GhostManager.instance.leavingGosts[i];
            GhostManager.instance.leavingGosts.Remove(gReturning);
            GhostManager.instance.allGhosts.Add(gReturning);
            gReturning.gID = GhostManager.instance.leavingGosts.IndexOf(gReturning);       }
    }
}
