using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    void Awake() {instance = this;}

    public List<RoomSlot> RoomSlots = new List<RoomSlot>();
    public List<GameObject> RoomPrefabs = new List<GameObject>();
    public List<Button> RoomButtons = new List<Button>();

    public GameObject Player;
    public GameObject BuildPanel;
    public GameObject SlotHolder;
    bool bCamOn;
    bool bPanelOpened;
    bool SlotHolderActive;
    public int selectedSlot;

    void Start()
    {
        for (int i = 0; i < RoomButtons.Count; i++) 
        {
            RoomButtons[i].GetComponent<RoomButton>().roomButtID = i;
            RoomButtons[i].onClick.AddListener(RoomButtons[i].GetComponent<RoomButton>().BuildRoom);
        }
    }

    void Update()
    {

    }

    public void OpenBuildPanel()
    {
        if(bPanelOpened)
        {
            CloseBuildPanel();
        }
        else
        {
            BuildPanel.SetActive(true);
            bPanelOpened = true;
            HandleBuildCamera();
        }
    }

    public void CloseBuildPanel()
    {
        BuildPanel.SetActive(false);
        bPanelOpened = false;
        Player.GetComponent<CharacterMovement>().enabled = enabled;
        CamFollowPlayer.instance.ZoomIn();
    }

    public void HandleBuildCamera()
    {
        Player.GetComponent<CharacterMovement>().enabled = !enabled;
        CamFollowPlayer.instance.ZoomOut();
    }

    public void BuildButton()
    {
        if(!bCamOn)
        {
            HandleBuildCamera();
            SlotHolder.SetActive(true);
        }
        else
        {
            CloseBuildPanel();
            SlotHolder.SetActive(false);
        }

    }

}
