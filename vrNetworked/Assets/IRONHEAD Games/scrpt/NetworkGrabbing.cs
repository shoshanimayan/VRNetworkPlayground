using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    PhotonView m_photonView;
    Rigidbody rb;
    public bool isHeld = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            rb.isKinematic = true;
            gameObject.layer = 13;//inhand
        }
        else {
            rb.isKinematic = false;
            gameObject.layer = 8;//interactable
        }
    }

    private void Awake()
    {
        m_photonView = GetComponent<PhotonView>();  
    }

    public void OnSelectEnter() {

        Debug.Log("select");
        m_photonView.RPC("StartNetworkedGrabbing", RpcTarget.AllBuffered);
        if (m_photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("already my object so no request ownership");
        }
        else {
            TransferOwnership();

        }


    }

    public void OnSelectExit() {
        Debug.Log("drop");
        m_photonView.RPC("StopNetWorkedGrabbing", RpcTarget.AllBuffered);

    }

    void TransferOwnership() {

        m_photonView.RequestOwnership(); 
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if (targetView != m_photonView) {
            return;
        }
        Debug.Log(targetView.name + " from " + requestingPlayer.NickName);
        m_photonView.TransferOwnership(requestingPlayer);
    }

    

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log("transfer complete "+targetView.Owner.NickName);
    }


    [PunRPC]
    public void StartNetworkedGrabbing() {
        isHeld = true;
        
    }
    [PunRPC]
    public void StopNetWorkedGrabbing() {
        isHeld = false;
    }

}
