using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dispenser : MonoBehaviour
{
    // Dispenses a Weapon/Ammo if certain conditions are met
    //Conditions: Cost? Player in range, player pressing f
    public GameObject reward;
    public GameObject rewardmodel;
    private GameObject rmodel;
    public GameObject ammo;
    private bool got = false;
    public int cost = 10;
    public GameObject interactpanel;
    public string rewardname;
    private bool close = false;
    private GameObject p;

    void Start()
    {
        p = GameObjectManager.player;
        //Check if prereqs have been set, instantiate preview model
        if(rewardmodel == null || reward ==null)
        {
            Debug.Log("Reward not set at gameobject"+this.name);
        }

        Instantiate(rewardmodel, this.transform.position+Vector3.right, Quaternion.identity).transform.parent=this.transform;

        interactpanel = GameObjectManager.interactpanel;
    }

    // Update is called once per frame
    void Update()
    {
        if (close&&Input.GetKeyDown(KeyCode.F) && p.GetComponent<Money>().playermoney >= cost)
        {
            if (!got)
            {
                Instantiate(reward, p.transform.position, Quaternion.identity);
                got = true;
            }
            else
            {
                Instantiate(ammo, p.transform.position, Quaternion.identity);
            }
            p.GetComponent<Money>().updatemoney(-cost);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.LogError("Pressed F");
        }

        if (other.CompareTag("Player")&&Input.GetKeyDown(KeyCode.F)&&other.GetComponent<Money>().playermoney>=cost)
        {
            if (!got)
            {
                Instantiate(reward, other.transform.position, Quaternion.identity);
                got = true;
            }
            else
            {
                Instantiate(ammo, other.transform.position, Quaternion.identity);
            }
            other.GetComponent<Money>().updatemoney(-cost);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            close = true;
        }
        interactpanel.SetActive(true);
        interactpanel.GetComponent<TextMeshProUGUI>().text = string.Format("Press F for {0}. Cost: {1}",rewardname,cost);
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
