using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    void Awake() {instance = this;}

    public List<GameObject> RoomPrefabs = new List<GameObject>();
    public List<Button> RoomButtons = new List<Button>();

    public GameObject Player;
    public GameObject BuildPanel;
    bool bPanelOpened;

    void Start()
    {
        for (int i = 0; i < RoomButtons.Count; i++) 
        {
            RoomButtons[i].GetComponent<RoomButton>().roomButtID = i;
            RoomButtons[i].onClick.AddListener(RoomButtons[i].GetComponent<RoomButton>().BuildRoom);
        }
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
            Player.GetComponent<CharacterMovement>().enabled = !enabled;
            CamFollowPlayer.instance.ZoomOut();
        }
    }

    public void CloseBuildPanel()
    {
        BuildPanel.SetActive(false);
        bPanelOpened = false;
        Player.GetComponent<CharacterMovement>().enabled = enabled;
        CamFollowPlayer.instance.ZoomIn();
    }


}
