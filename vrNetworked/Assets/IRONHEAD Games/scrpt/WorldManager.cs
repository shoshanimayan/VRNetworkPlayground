using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;


public class WorldManager : MonoBehaviourPunCallbacks
{
    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    
    }

    public static WorldManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this) { 
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    #region callback
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined " + PhotonNetwork.CurrentRoom.Name + " count " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {

        PhotonNetwork.LoadLevel(1);
    }

    #endregion

}
