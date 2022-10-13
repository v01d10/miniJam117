using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCarrying : MonoBehaviour
{
[Header("Move Ghost")]

    private Vector3 offset = new Vector3(0f, 0f, 3f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.25f;
    public static bool ghostFollow;

    void Update()
    {
        if(ghostFollow)
        {
            Vector3 targetPosition = transform.position;
            GhostDetection.selectedGhost.transform.position = Vector3.SmoothDamp(GhostDetection.selectedGhost.transform.position, targetPosition, ref velocity, smoothTime);
        
        } 
    }

    void OnTriggerStay()
    {
        if(Input.GetKeyDown(KeyManager.pickKey) && ghostFollow)
            ghostFollow = false;
    }
}
