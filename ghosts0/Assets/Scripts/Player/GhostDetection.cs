using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static GhostManager;

public class GhostDetection : MonoBehaviour
{
    public static Ghost selectedGhost;

    public GameObject showGhostPanel;
    public GameObject ghostPanel;
    public bool gPanelOpened;

[Header("Text")]
    public TextMeshProUGUI StrLvlText;
    public TextMeshProUGUI StrXpText;
    public TextMeshProUGUI ScarLvlText;
    public TextMeshProUGUI ScarXpText;
    public TextMeshProUGUI HappinessText;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ghost"))
        {
            if(!gPanelOpened)
            {
                selectedGhost = other.GetComponent<Ghost>();
                showGhostPanel.SetActive(true);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyManager.interactKey) && !gPanelOpened)
        {
            showGhostPanel.SetActive(false);
            ghostPanel.SetActive(true);
            gPanelOpened = true;

            HandleGhostText();
        }

        if(Input.GetKeyDown(KeyManager.pickKey) && !GhostCarrying.ghostFollow)
        {
            GhostCarrying.ghostFollow = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ghost"))
        {
            CloseGhostUI();
        }
    }

    public void CloseGhostUI()
    {
        showGhostPanel.SetActive(false);
        ghostPanel.SetActive(false);
        gPanelOpened = false;
    }

    void HandleGhostText()
    {
        StrLvlText.text = gManager.allGhosts[selectedGhost.gID].gStrength.ToString();
        StrXpText.text = gManager.allGhosts[selectedGhost.gID].gStrengthExp.ToString();
        ScarLvlText.text = gManager.allGhosts[selectedGhost.gID].gScarinnes.ToString();
        ScarXpText.text = gManager.allGhosts[selectedGhost.gID].gScarinnesExp.ToString();
        HappinessText.text = gManager.allGhosts[selectedGhost.gID].gHappiness.ToString();
    }

}
