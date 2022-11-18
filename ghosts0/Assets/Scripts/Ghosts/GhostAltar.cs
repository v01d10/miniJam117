using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAltar : MonoBehaviour
{
    public static GhostAltar instance;
    void Awake() {instance = this;}

    public GameObject Ghost;
    public Transform GhostHolder;

    public float SummonPrice;

    void Start()
    {
        for (int i = 0; i < 3; i++) Instantiate(Ghost, GhostHolder);

    }

    public void SummonGhost()
    {
        if(ResourceManager.instance.Money >= SummonPrice)
        {
            CamShaker.instance.SpawnShake();
            GhostDetection.instance.summonGhostPanel.SetActive(false);
            GhostDetection.instance.summonGhostPanelOpened = false;
            ResourceManager.instance.Money -= SummonPrice;
            SummonPrice += SummonPrice * 1.5f;
            Instantiate(Ghost, GhostHolder);
        }
        else
        {
            print("Not enough money");
            GhostDetection.instance.summonGhostPanel.SetActive(false);
            GhostDetection.instance.summonGhostPanelOpened = false;
                 
        }
    }
}
