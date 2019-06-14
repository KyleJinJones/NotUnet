using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///This script will be attached to a gameobject to hold all the functionality that a button needs when paused.
public class ButtonFunction : MonoBehaviour
{
    [SerializeField]private GameObject parentUI;
    //set the time scale to 0 to stop all objects from moving in the scene
    public void Pause()
    {
        Time.timeScale = 0;
    }

    //set the time scale to 1 to allow all objects to move in the scene
    public void Resume()
    {
        Time.timeScale = 1;
    }

    //quit the game completely, back the the Desktop
    public void Quit()
    {
        Application.Quit();
    }
}
