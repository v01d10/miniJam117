using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSnapping : MonoBehaviour
{
    public Vector3 targetPosition;
    public Collider targetCollider;
    public Collider myCollider;
    public float snapDistance = 1;

    void Update()
    {
        transform.position = targetPosition;
        Vector3 myClosestPoint = myCollider.ClosestPoint(targetCollider.transform.position);
        Vector3 targetClosestPoint = targetCollider.ClosestPoint(myClosestPoint);
        Vector3 offset = targetClosestPoint - myClosestPoint;
        if(offset.magnitude < snapDistance)
        {
            transform.position += offset;
        }
    }
}
