using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Starter : MonoBehaviour
{
    public WaveManager Manager;
    public GameObject Dispensers;
    public GameObject interactpanel;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObjectManager.wm;
        Dispensers = GameObjectManager.dispensers;
        interactpanel = GameObjectManager.interactpanel;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && other.CompareTag("Player"))
        {
            Manager.enabled=true;
            Dispensers.SetActive(false);
            //this.gameObject.SetActive(false);
            interactpanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interactpanel.SetActive(true);
        interactpanel.GetComponent<TextMeshProUGUI>().text = "Press F to Start";
    }

    private void OnTriggerExit(Collider other)
    {
        interactpanel.SetActive(false);
    }
}
