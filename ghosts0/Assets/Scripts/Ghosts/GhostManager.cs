using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public static GhostManager gManager;
    void Awake() {gManager = this;}

    public List<Ghost> allGhosts = new List<Ghost>();
    public List<Ghost> sleepingGhosts = new List<Ghost>();
    public List<Ghost> relaxingGhosts = new List<Ghost>();
    public List<Ghost> trainingGhosts = new List<Ghost>();

    public GameObject GhostPrefab;
    public Transform GhostSpawn;

    void Start()
    {
        for (int i = 0; i < allGhosts.Count; i++) allGhosts[i].gID = i;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            SpawnGhost();
        }   
    }

    public void SpawnGhost()
    {
        Instantiate(GhostPrefab, GhostSpawn, this.transform);
    }
}
