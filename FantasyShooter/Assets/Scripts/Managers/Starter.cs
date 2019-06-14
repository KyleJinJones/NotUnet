using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Starter : MonoBehaviour
{
    public WaveManager Manager;
    public GameObject Dispensers;
    public GameObject interactpanel;
    public GameObject interactpanel2;
    private bool close = false;
    private bool close2 = false;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObjectManager.wm;
        Dispensers = GameObjectManager.dispensers;
        interactpanel = GameObjectManager.interactpanel;
        interactpanel2 = GameObjectManager.interactpanel2;
    }

    private void Update()
    {
        if (close&&(Input.GetKeyDown(KeyCode.F)||Input.GetKeyDown(KeyCode.Joystick1Button0)))
        {
            StartGame();
            close = false;
            close2 = false;
        }
        else if (close2 && (Input.GetKeyDown(KeyCode.Joystick2Button0)))
        {
            StartGame();
            close2 = false;
            close = false;
        }
    }

    private void StartGame() 
    {

            Manager.enabled=true;
            Dispensers.SetActive(false);
            //this.gameObject.SetActive(false);
            interactpanel.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

            GameObject temp = interactpanel;

            if (other.name == "Player2")
            {
                temp = interactpanel2;
                close2 = true;
            }
            else
            {
                close = true;
            }

            temp.SetActive(true);
            temp.GetComponent<TextMeshProUGUI>().text = "Press F or X to Start";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           

            if (other.name == "Player2")
            {
                interactpanel2.SetActive(false);
            }
            else
            {
                interactpanel.SetActive(false);
            }
        }
    }
}
