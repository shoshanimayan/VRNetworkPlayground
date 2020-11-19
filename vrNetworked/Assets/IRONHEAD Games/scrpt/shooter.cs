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
        if (held)
        {

            var clone = PhotonNetwork.Instantiate(bullet.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 20));
        }
           
    }
    // Update is called once per frame
   
}
