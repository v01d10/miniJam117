using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public static Teleport instance;
    void Awake() {instance = this;}
    public Transform Basement;
    public Transform Outside;
    public Collider Player;

    float PortTimer;

    void Update()
    {
        if(!CharacterMovement.CanPort) PortTimer += Time.deltaTime;
        if(PortTimer >= 2)
        {
            CharacterMovement.CanPort = true;
            PortTimer = 0;
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player = other;

            if(CharacterMovement.CanPort && CharacterMovement.outside)
            {
                PortIn();
            }
            
            if(CharacterMovement.CanPort && !CharacterMovement.outside)
            {
                PortOut();
            }         
        }
 
    }
    
    public void PortIn()
    {
            print("port in");
            CharacterMovement.CanPort = false;
            Player.transform.position = Basement.position;
            CharacterMovement.outside = false;

    }

    public void PortOut()
    {
            print("port out");
            CharacterMovement.CanPort = false;
            Player.transform.position = Outside.position;
            CharacterMovement.outside = true;
    }
}
