using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy e = other.GetComponent<Enemy>();
            e.DecreaseHealth(PlayerLevels.instance.Endurance);
        }
    }
}
