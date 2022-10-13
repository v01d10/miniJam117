using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
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
                print("port in");
                CharacterMovement.CanPort = false;
                CharacterMovement.outside = false;
                Player.transform.position = Basement.position;
            }
            
            if(CharacterMovement.CanPort && !CharacterMovement.outside)
            {
                print("port out");
                CharacterMovement.CanPort = false;
                CharacterMovement.outside = true;
                Player.transform.position = Outside.position;
            }         
        }
 
    }
    
    void PortIn()
    {

    }

    void PortOut()
    {

    }
}
