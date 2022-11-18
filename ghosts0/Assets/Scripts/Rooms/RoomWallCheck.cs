using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWallCheck : MonoBehaviour
{
    public Collider Wall;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall") && Wall.enabled)
        {
            GameObject wall = transform.parent.gameObject;
            //Collider oppositeWall = other.GetComponentInParent<Collider>();
            print("hit wall");
            other.gameObject.SetActive(false);
            wall.SetActive(false);
        }
    }
}
