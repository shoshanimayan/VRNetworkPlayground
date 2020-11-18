using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject GoHome;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        GoHome.GetComponent<Button>().onClick.AddListener(WorldManager.Instance.LeaveRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
