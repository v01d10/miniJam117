using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public static CamFollowPlayer instance;
    void Awake() {instance = this;}
    public Vector3 offset = new Vector3(0f, 0f, 10f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.25f;

    public Transform Target;
    public Animator CamAnim;

    void Update()
    {
        Vector3 targetPosition = Target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void ZoomIn()
    {
        CamAnim.Play("CamZoom");
    }

    public void ZoomOut()
    {
        CamAnim.Play("CamZoomOut");

    }
   
}
