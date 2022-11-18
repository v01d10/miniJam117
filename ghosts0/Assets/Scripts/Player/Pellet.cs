using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    float LifeTimer;

    public float Damage;

    void Start()
    {
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy hitEnemy = other.GetComponent<Enemy>();

            if(hitEnemy.EnemyHealth > Damage)
                hitEnemy.DecreaseHealth(Damage);

            else
            {
                hitEnemy.DecreaseHealth(Damage);
                Destroy(gameObject);
                StatManager.instance.enemiesKilled++;
            }
        }
    }
}
