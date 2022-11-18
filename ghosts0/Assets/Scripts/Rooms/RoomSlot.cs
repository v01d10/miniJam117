using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSlot : MonoBehaviour
{
    public int rSlotID;

    void Start()
    {
        RoomManager.instance.RoomSlots.Add(this);
        rSlotID = RoomManager.instance.RoomSlots.IndexOf(this);
    }

    void OnMouseDown()
    {
        RoomManager.instance.OpenBuildPanel();
        RoomManager.instance.selectedSlot = rSlotID;
    }
}
