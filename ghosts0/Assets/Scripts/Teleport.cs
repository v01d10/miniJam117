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

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player = other;

            if(CharacterMovement.CanPort && CharacterMovement.outside && GameManager.Instance.State == GameState.Day)
            {
                StartCoroutine("PortIN");
                DayNightCycle.instance.HandleNightLight();
            }
            
            if(CharacterMovement.CanPort && !CharacterMovement.outside && GameManager.Instance.State == GameState.Day)
            {
                StartCoroutine("PortOUT");
                DayNightCycle.instance.HandleDayLight();
            }         
        }
 
    }
    
    public void PortIn()
    {
        StartCoroutine("PortIN");
    }

    public void PortOut()
    {
        StartCoroutine("PortOUT");
    }

    public IEnumerator PortOUT()
    {
            print("port out");
            CharacterMovement.CanPort = false;
            Player.transform.position = Outside.position;
            CharacterMovement.outside = true;

            yield return new WaitForSeconds(1.5f);
            CharacterMovement.CanPort = true;
    }

    public IEnumerator PortIN()
    {
            print("port in");
            CharacterMovement.CanPort = false;
            Player.transform.position = Basement.position;
            CharacterMovement.outside = false;

            yield return new WaitForSeconds(1.5f);
            CharacterMovement.CanPort = true;
    }
}
