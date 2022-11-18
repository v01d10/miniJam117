using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour {
    public static NavigationBaker instance;
    void Awake(){instance = this;}

    public List<NavMeshSurface> surfaces;
    public List<Transform> objectsToRotate;

    // Use this for initialization
    void Update () 
    {

        for (int j = 0; j < objectsToRotate.Count; j++) 
        {
            objectsToRotate [j].localRotation = Quaternion.Euler (new Vector3 (0, 50*Time.deltaTime, 0) + objectsToRotate [j].localRotation.eulerAngles);
        }

        for (int i = 0; i < surfaces.Count; i++) 
        {
            surfaces [i].BuildNavMesh ();    
        }    
    }

}