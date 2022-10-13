using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrefab : MonoBehaviour
{
    bool built;

    public GameObject Preview;
    public GameObject Prefab;
    public LayerMask hitLayers;


    void Update()
    {
        if(!built)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if(Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
            {
                transform.position = hit.point;
            }           
            
            if(Input.GetMouseButtonDown(0))
            {
                built = true;
                Destroy(Preview);
                Prefab.SetActive(true);
                RoomManager.instance.CloseBuildPanel();

            }
        }

        

    }
}
