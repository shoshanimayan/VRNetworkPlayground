using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Photon.Pun.UtilityScripts;


public class shooter : MonoBehaviour
{
    private XRGrabInteractable grabber;
    public GameObject spawnPoint;
    public GameObject bullet;
    public bool held = false;
    // Start is called before the first frame update
    void Start()
    {
        grabber = GetComponent<XRGrabInteractable>();
    }

    public void OnSelectEnter() { 
        held = true;
        Debug.Log("shot");

    }



    public void OnSelectExit() { held = false; }

    public void OnActivate() {
        SpawnBullet();

    }

    [PunRPC]
    private void SpawnBullet() {
        if (held)
        {

            var clone = PhotonNetwork.Instantiate(bullet.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 20));
            clone.GetComponent<bullet>().owner = PhotonNetwork.LocalPlayer.GetPlayerNumber();

        }
    }

}
