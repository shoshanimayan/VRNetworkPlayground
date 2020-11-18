using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

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

    public void OnSelectEnter() { held = true;
        Debug.Log("shot");
    }

    public void OnSelectExit() { held = false; }

    public void OnActivate() {
        if(held)
            PhotonNetwork.Instantiate(bullet.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
    // Update is called once per frame
   
}
