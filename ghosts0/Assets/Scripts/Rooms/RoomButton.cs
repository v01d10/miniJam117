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
        Instantiate(RoomManager.instance.RoomPrefabs[roomButtID], RoomManager.instance.RoomSlots[RoomManager.instance.selectedSlot].transform.position, RoomManager.instance.RoomSlots[RoomManager.instance.selectedSlot].transform.rotation);
        Destroy(RoomManager.instance.RoomSlots[RoomManager.instance.selectedSlot].gameObject);
        RoomManager.instance.CloseBuildPanel();
        RoomManager.instance.selectedSlot = 0;
        RoomManager.instance.SlotHolder.SetActive(false);
    }
}
