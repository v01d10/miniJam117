using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager statManager;
    void Awake() {statManager = this;}

    public int survivedNights;
    public int enemiesKilled;
}
