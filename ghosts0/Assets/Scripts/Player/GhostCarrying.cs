using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCarrying : MonoBehaviour
{
    public static GhostCarrying instance;
    void Awake(){instance = this;}

[Header("Move Ghost")]
    private Vector3 offset = new Vector3(0f, 0f, 3f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.25f;
    public bool ghostFollow;
    public Transform Player;

    void Start()
    {
        Player = transform;
    }

    void Update()
    {
        if(ghostFollow)
        {
            GhostDetection.instance.selectedGhost.gAgent.enabled = !enabled;
            GhostDetection.instance.selectedGhost.transform.position = Vector3.SmoothDamp(GhostDetection.instance.selectedGhost.transform.position, transform.position, ref velocity, smoothTime);
        } 
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ghost") && Input.GetKeyDown(KeyManager.pickKey) && other.GetComponent<Ghost>().gFollow)
        {
            ghostFollow = false;
            other.GetComponent<Ghost>().gFollow = false;
            GhostDetection.instance.selectedGhost.gAgent.enabled = enabled;
            GhostDetection.instance.selectedGhost = null;
            GhostDetection.instance.CloseGhostUI();
        }

    }
}
