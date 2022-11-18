using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    void Awake() {instance = this;}

    public List<Enemy> enemies = new List<Enemy>();
    public Transform[] spawnLocations;
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public List<Enemy> EnemiesToKill = new List<Enemy>();

    private float spawnInterval;
    private float spawnTimer;
    public bool waveFinished;

    void FixedUpdate()
    {
        if(spawnTimer <0)
        {
            if(enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocations[Random.Range(0, spawnLocations.Length)].position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = 2;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();

        while(waveValue > 0)
        {
            int randEnemyiD = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyiD].EnemyCost;

            if(waveValue-randEnemyCost>=0)
            {
                generatedEnemies.Add(enemies[randEnemyiD].EnemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue <= 0)
            {
                break;
            }
        }

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;

    }

    public void FinishWave()
    {
        Teleport.instance.Player.transform.position = Teleport.instance.Basement.position;
        GameManager.Instance.UpdateGameState(GameState.Day);
        currWave++;
        StatManager.instance.survivedNights++;

    }
}

