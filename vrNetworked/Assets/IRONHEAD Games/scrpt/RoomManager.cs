using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    public TextMeshProUGUI schoolAmount;
    public TextMeshProUGUI outdoorAmount;


    private string mapType = "";

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if (!PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.ConnectUsingSettings();

        }
        else {
            PhotonNetwork.JoinLobby();
        }
    }
    #region ui

    public void JoinRandomRoom() {
        PhotonNetwork.JoinRandomRoom();
    }

    public void EnterOutdoor()
    {
        mapType = MultiplayerVRConstants.Map_Type_Outdoor;

        ExitGames.Client.Photon.Hashtable properties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.Map_Type_Key, mapType } };
        PhotonNetwork.JoinRandomRoom(properties, 0);

    }

    public void EnterSchool() {
        mapType = MultiplayerVRConstants.Map_Type_School;
        ExitGames.Client.Photon.Hashtable properties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.Map_Type_Key, mapType } };
        PhotonNetwork.JoinRandomRoom(properties,0);
    }

    #endregion

    #region photon callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected again");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("joined lobby");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoin();
            
     }

    public override void OnCreatedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name);

    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (roomList.Count == 0) {
            outdoorAmount.text = 0 + " / " + 20;
            schoolAmount.text = 0 + " / " + 20;

        }
        foreach (RoomInfo room in roomList) {
            if (room.Name.Contains(MultiplayerVRConstants.Map_Type_Outdoor))
            {
                outdoorAmount.text = room.PlayerCount + " / " + 20;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.Map_Type_School)) {
                schoolAmount.text = room.PlayerCount + " / " + 20;

            }
        }
    }

    public override void OnJoinedRoom()
    {

        Debug.Log(PhotonNetwork.NickName+" joined "+ PhotonNetwork.CurrentRoom.Name+" count "+ PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.Map_Type_Key)) {
            object mapType;
        if(PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstants.Map_Type_Key, out mapType))
            {
                Debug.Log((string)mapType);
                if ((string)mapType == MultiplayerVRConstants.Map_Type_School)
                {
                    PhotonNetwork.LoadLevel("World_School");
                }
                else if ((string)mapType == MultiplayerVRConstants.Map_Type_Outdoor) {
                    PhotonNetwork.LoadLevel("World_Outdoor");

                }
                else { 
                
                }

            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined " + PhotonNetwork.CurrentRoom.Name + " count " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion

    private void CreateAndJoin() {
        string randomName = "room_" +mapType+ Random.Range(0, 1000);
        RoomOptions room = new RoomOptions();
        room.IsOpen = true;
        room.IsVisible = true;
        room.MaxPlayers = 20;

        string[] roomPropsLobby = { MultiplayerVRConstants.Map_Type_Key };
        ExitGames.Client.Photon.Hashtable custumRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.Map_Type_Key, mapType } };

        room.CustomRoomPropertiesForLobby = roomPropsLobby;
        room.CustomRoomProperties = custumRoomProperties;



        PhotonNetwork.CreateRoom(randomName,room);
    }
}
