using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager instance;
    void Awake() {instance = this;}

    public int survivedNights;
    public int enemiesKilled;
}
