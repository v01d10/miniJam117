using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    void Awake(){instance = this;}

    public float Money;
    public float Ectoplasm;
    public float Bullets;

    void Start()
    {
        if(!GameManager.Instance.FirstTime)
        {
            Money = saveM.PD.Money;
            Ectoplasm = saveM.PD.Money;
            Bullets = saveM.PD.Bullets;

        }
    }

}
