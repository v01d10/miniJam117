using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevels : MonoBehaviour
{
    public static PlayerLevels instance;
    void Awake() { instance = this;}

    public int Lvl;
    public float Exp;
    public float ExpNeeded;

[Header("Attributes")]
    public int AtPoints;
    public int Endurance;
    public int Speed;
    public int Inteligence;

    void FixedUpdate()
    {
        if(Exp > ExpNeeded)
        {
            float expTrans = Exp - ExpNeeded;
            Lvl++;
            AtPoints++;
            Exp = 0 + expTrans;
            ExpNeeded *= 1.5f;
        }
    }
}
