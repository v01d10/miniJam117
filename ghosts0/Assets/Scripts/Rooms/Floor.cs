using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Floor : MonoBehaviour
{
    void Start()
    {
        NavigationBaker.instance.surfaces.Add(GetComponent<NavMeshSurface>());
    }
}
