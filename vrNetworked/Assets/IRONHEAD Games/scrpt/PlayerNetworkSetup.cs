using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject LocalXrRig;
    public TextMeshProUGUI playernNameText;
    public GameObject mainAvatar;

    public GameObject head;
    public GameObject body;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        { //local
            LocalXrRig.SetActive(true);
            gameObject.GetComponent<MovementController>().enabled = true;
            gameObject.GetComponent<AvatarInputConverter>().enabled = true;
            SetLayerRecursively(head,11);
            SetLayerRecursively(body,12);

            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            foreach (var item in teleportationAreas) {
                item.teleportationProvider = LocalXrRig.GetComponent<TeleportationProvider>();
            }

            mainAvatar.AddComponent<AudioListener>();
        }
        else {//remote
            LocalXrRig.SetActive(false);
            gameObject.GetComponent<MovementController>().enabled = false;
            gameObject.GetComponent<AvatarInputConverter>().enabled = false;
            SetLayerRecursively(head, 0);
            SetLayerRecursively(body, 0);
        }

        if (playernNameText!= null) {
            playernNameText.text = photonView.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
