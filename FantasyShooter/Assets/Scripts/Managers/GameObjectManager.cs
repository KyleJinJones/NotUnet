using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    //Keeps track of a bunch of commonly used gameobjects to reduce calls to gameobject.find
    public static GameObject player;
    public static GameObject interactpanel;
    public static GameObject dispensers;
    public static WaveManager wm;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interactpanel = GameObject.FindGameObjectWithTag("Interact");
        dispensers = GameObject.FindGameObjectWithTag("Dispensers");
        wm = GetComponent<WaveManager>();

        interactpanel.SetActive(false);
        wm.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
