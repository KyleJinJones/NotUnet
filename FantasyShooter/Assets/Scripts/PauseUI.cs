using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu == null)
            Debug.Log("Put in the Pause Menu for this to WORK!");
        else
            pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            //we use time scale to check if the menu should show in the game
            //if (Time.timeScale == 1)
            //    Time.timeScale = 0;
            //else
            //    Time.timeScale = 1;
            Debug.Log("Unity Close");
            Application.Quit();
        }
        //reveal mouse and menu when screen is paused (time scale is 0)
        //Cursor.visible = (Time.timeScale == 0);
        //pauseMenu.SetActive((Time.timeScale == 0));

        //Debug.Log("THE CURRENT TIME SCALE IS: " + Time.timeScale.ToString());    
    }
}
