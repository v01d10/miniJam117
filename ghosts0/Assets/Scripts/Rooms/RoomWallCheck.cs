using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWallCheck : MonoBehaviour
{
    RaycastHit hit;
    Collider Wall;
    public float MaxDistance = 1.5f;

    void Start()
    {
        Wall = gameObject.GetComponent<Collider>();
    }

    void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.forward, out hit, MaxDistance))
        {
            if(hit.collider.CompareTag("Wall") && Wall.enabled)
            {
                print("hit wall");
                hit.collider.enabled = !enabled;
                Wall.enabled = !enabled;
            }
        }
    }
}
