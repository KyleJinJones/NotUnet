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
    private bool got2 = false;
    public int cost = 10;
    public GameObject interactpanel;
    public GameObject interactpanel2;
    public string rewardname;
    private bool close = false;
    private bool close2 = false;
    private GameObject p1;
    private GameObject p2;

    void Start()
    {
        p1 = GameObjectManager.player1;
        p2 = GameObjectManager.player2;
        //Check if prereqs have been set, instantiate preview model
        if (rewardmodel == null || reward ==null)
        {
            Debug.Log("Reward not set at gameobject"+this.name);
        }

        Instantiate(rewardmodel, this.transform.position+Vector3.right, Quaternion.identity).transform.parent=this.transform;

        interactpanel = GameObjectManager.interactpanel;
        interactpanel2 = GameObjectManager.interactpanel2;
    }

    // Update is called once per frame
    void Update()
    {
        if (close && (Input.GetKeyDown(KeyCode.F)||Input.GetKeyDown(KeyCode.Joystick1Button0)) && p1.GetComponent<Money>().playermoney >= cost)
        {
            GiveWeapon(p1, got,1);
        }
        else if(close2&&Input.GetKeyDown(KeyCode.Joystick2Button0)&& p2.GetComponent<Money>().playermoney >= cost)
        {
            GiveWeapon(p2, got2,2);
        }


    }

    private void GiveWeapon(GameObject player, bool hasweapon, int playerid)
    {
        if (!hasweapon)
        {
            Instantiate(reward, player.transform.position, Quaternion.identity);
            hasweapon = true;
            if (playerid == 1)
            {
                got = true;
            }
            else
            {
                got2 = true;
            }
        }
        else
        {
            Instantiate(ammo, player.transform.position, Quaternion.identity);
        }
        player.GetComponent<Money>().updatemoney(-cost);
    

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

            GameObject temp = interactpanel;
            
            if (other.name == "Player2")
            {
                temp = interactpanel2;
            }
            temp.SetActive(true);
            temp.GetComponent<TextMeshProUGUI>().text = string.Format("Press F for {0}. Cost: {1}", rewardname, cost);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            close = false;
            GameObject temp = interactpanel;
            if (other.name == "Player2")
            {
                temp = interactpanel2;
            }
            temp.SetActive(false);

        }

        
    }
}
