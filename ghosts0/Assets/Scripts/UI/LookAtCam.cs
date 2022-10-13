using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform, Vector3.forward);
    }
}
