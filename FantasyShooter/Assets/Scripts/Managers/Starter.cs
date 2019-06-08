using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Starter : MonoBehaviour
{
    public WaveManager Manager;
    public GameObject Dispensers;
    public GameObject interactpanel;
    private bool close = false;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObjectManager.wm;
        Dispensers = GameObjectManager.dispensers;
        interactpanel = GameObjectManager.interactpanel;
    }

    private void Update()
    {
        if (close&&Input.GetKeyDown(KeyCode.F))
        {
            StartGame();
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
            close = true;
        }
        interactpanel.SetActive(true);
        interactpanel.GetComponent<TextMeshProUGUI>().text = "Press F to Start";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            close = false;
        }
        interactpanel.SetActive(false);
    }
}
