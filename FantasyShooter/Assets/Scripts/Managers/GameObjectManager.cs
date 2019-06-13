using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameObjectManager : MonoBehaviour
{
    //Keeps track of a bunch of commonly used gameobjects to reduce calls to gameobject.find
    public static GameObject player1;
    public static GameObject interactpanel;
    public static GameObject dispensers;
    public static WaveManager wm;
    public static GameObject player2;
    public static GameObject interactpanel2;
    

    void Awake()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Player");
        if (temp[0].GetComponent<vp_FPInput>().player2)
        {
            player2 = temp[0];
            player1 = temp[1];
        }
        else
        {
            player2 = temp[1];
            player1 = temp[0];
        }

        //player1 = GameObject.FindGameObjectWithTag("Player");
        //player2 = GameObject.FindGameObjectsWithTag("Player")[1];

        temp = GameObject.FindGameObjectsWithTag("Interact");
        if (temp[0].name == "Interact1")
        {
            interactpanel = temp[0];
            interactpanel2 = temp[1];
        }
        else
        {
            interactpanel = temp[1];
            interactpanel2 = temp[0];
        }
        
        
        //interactpanel = GameObject.FindGameObjectWithTag("Interact");
        //interactpanel2 = GameObject.FindGameObjectsWithTag("Interact")[1];

        dispensers = GameObject.FindGameObjectWithTag("Dispensers");
        wm = GetComponent<WaveManager>();

        interactpanel.SetActive(false);
        interactpanel2.SetActive(false);
        wm.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
