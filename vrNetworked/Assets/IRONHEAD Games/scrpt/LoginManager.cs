using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class LoginManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField PlayerName;
    #region Unity methods
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region ui

    public void ConnectToPhotonServer()
    {

        if (PlayerName != null)
        {

            PhotonNetwork.NickName = PlayerName.text;
        }
        PhotonNetwork.ConnectUsingSettings();


    }



    #endregion

    #region photon callbacks
    public override void OnConnected()
    {
        Debug.Log("connect");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connectMaster " +PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel(1);
    }
    #endregion
}
