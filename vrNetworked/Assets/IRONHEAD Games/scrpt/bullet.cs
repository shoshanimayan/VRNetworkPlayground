using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public int owner;
    bool firsthit = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
     
        StartCoroutine(kill());

    }

    private IEnumerator kill() {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);


    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        if (collision.gameObject.layer == 10 && firsthit)
        {
            if (collision.gameObject.GetComponent<PhotonView>().Owner.GetPlayerNumber() != owner)
            {
                PhotonNetwork.LocalPlayer.AddScore(1);
                Destroy(gameObject);
            }

        }
        else { 
            firsthit = false;

        }
    }
}
