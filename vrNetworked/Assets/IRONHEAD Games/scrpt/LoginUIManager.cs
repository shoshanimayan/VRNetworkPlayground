using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUIManager : MonoBehaviour
{


    public GameObject optionsPanel;
    public GameObject withNamePanel;
    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(true);
        withNamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
