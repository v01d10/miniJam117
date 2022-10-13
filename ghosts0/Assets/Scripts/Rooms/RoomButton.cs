using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomButton : MonoBehaviour
{
    public static RoomButton instance;
    void Awake() {instance = this;}

    public int roomButtID;
    public Transform RoomsHolder;

    public void BuildRoom()
    {
        Instantiate(RoomManager.instance.RoomPrefabs[roomButtID], Input.mousePosition, RoomsHolder.rotation, RoomsHolder);
        RoomManager.instance.CloseBuildPanel();
    }
}
