using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject menu;
    public GameObject openWorld;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        openWorld.SetActive(false);
    }

    // Update is called once per frame
    public void OnWorldsButtonClicked()
    {
        if (openWorld != null) { openWorld.SetActive(true); }
    }

    public void OnHomeButtonClicked()
    {

    }

    public void OnAvatarButtonClicked()
    {

    }
}


