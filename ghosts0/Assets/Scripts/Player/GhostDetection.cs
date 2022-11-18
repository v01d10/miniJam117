using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static GhostManager;

public class GhostDetection : MonoBehaviour
{
    public static GhostDetection instance;
    void Awake() {instance = this;}

    public Ghost selectedGhost;
    public GameObject showGhostPanel;
    public GameObject ghostPanel;
    public bool gPanelOpened;

[Header("Ghosts")]
    public Animator gPanelAnim;
    public TextMeshProUGUI StrLvlText;
    public Image StrXp;
    public TextMeshProUGUI ScarLvlText;
    public Image ScarXp;
    public Image HappinesBar;
    public Image EctoplasmBar;
    public TextMeshProUGUI HPtext;
    public Image HPbar;
    public TextMeshProUGUI KilledText;

[Header("Altar")]
    public GameObject summonGhostPanel;
    public bool summonGhostPanelOpened;
    public TextMeshProUGUI SummonPrice;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ghost") && GameManager.Instance.State == GameState.Day && !GhostCarrying.instance.ghostFollow)
        {
            if(!gPanelOpened)
            {
                showGhostPanel.SetActive(true);
                Invoke("CloseShowGhostPanel", 3);
            }
        }

        else if(other.CompareTag("Altar") && GameManager.Instance.State == GameState.Day && !summonGhostPanelOpened)
        {
            summonGhostPanel.SetActive(true);
            summonGhostPanelOpened = true;
            SummonPrice.text = other.GetComponent<GhostAltar>().SummonPrice.ToString();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ghost") && GameManager.Instance.State == GameState.Day)
        {
            if(Input.GetKeyDown(KeyManager.interactKey) && !gPanelOpened)
            {
                selectedGhost = other.GetComponent<Ghost>();
                showGhostPanel.SetActive(false);
                ghostPanel.SetActive(true);
                gPanelOpened = true;
                gPanelAnim.Play("GhostPanelOpen");

                HandleGhostText();
            }

            if(Input.GetKeyDown(KeyManager.pickKey) && gPanelOpened)
            {
                if(!selectedGhost.gFollow)
                {
                    GhostCarrying.instance.ghostFollow = true;
                    Invoke("setGhostFollow", 1);
                    CloseGhostUI();
                }

            }
        }

        else if(other.CompareTag("Altar"))
        {
            if(Input.GetKeyDown(KeyManager.interactKey) && summonGhostPanelOpened)
            {
                GhostAltar.instance.SummonGhost();
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ghost") && GameManager.Instance.State == GameState.Day && gPanelOpened)
        {
            gPanelAnim.Play("GhostPanelClose");
            Invoke("CloseGhostUI", 1);
        }
        else if(other.CompareTag("Altar") && summonGhostPanelOpened)
        {
            summonGhostPanel.SetActive(false);
            summonGhostPanelOpened = false;
        }

    }

    public void CloseShowGhostPanel()
    {
        showGhostPanel.SetActive(false);

    }

    public void CloseGhostUI()
    {
        showGhostPanel.SetActive(false);
        ghostPanel.SetActive(false);
        gPanelOpened = false;
    }

    void HandleGhostText()
    {
        float scrExpPerc = selectedGhost.gScarinnesExp / selectedGhost.gScarinessExpNeeded;
        float strExpPerc = selectedGhost.gStrengthExp / selectedGhost.gStrengthExpNeeded;
        float happPerc = selectedGhost.gHappiness / selectedGhost.gMaxHappines;
        float ectoPerc = selectedGhost.gEctoplasmLevel / selectedGhost.gMaxEctoplasmLevel;
        float hpPerc = selectedGhost.gHealth / selectedGhost.gMaxHealth;

        StrLvlText.text = GhostManager.instance.allGhosts[selectedGhost.gID].gStrength.ToString();
        StrXp.fillAmount = strExpPerc;
        
        ScarLvlText.text = GhostManager.instance.allGhosts[selectedGhost.gID].gScarinnes.ToString();
        ScarXp.fillAmount = scrExpPerc;

        HPtext.text = GhostManager.instance.allGhosts[selectedGhost.gID].gHealth.ToString() + " / " + GhostManager.instance.allGhosts[selectedGhost.gID].gMaxHealth.ToString();
        HPbar.fillAmount = hpPerc;

        HappinesBar.fillAmount = happPerc;

        EctoplasmBar.fillAmount = ectoPerc;

        KilledText.text = GhostManager.instance.allGhosts[selectedGhost.gID].gKilled.ToString();
    }

    public void setGhostFollow()
    {
        selectedGhost.gFollow = true;
    }

}
