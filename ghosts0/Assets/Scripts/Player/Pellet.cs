using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    float LifeTimer;

    public float Damage;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy hitEnemy = other.GetComponent<Enemy>();

            hitEnemy.Health -= Damage;

            if(hitEnemy.Health <= 0)
            {
                Destroy(hitEnemy.gameObject);
                PlayerLevels.instance.Exp += hitEnemy.ExpToGive;
                gameObject.SetActive(false);
            }
        }
    }
}
