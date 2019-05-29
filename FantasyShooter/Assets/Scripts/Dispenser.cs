using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    // Dispenses a Weapon/Ammo if certain conditions are met
    //Conditions: Cost? Player in range, player pressing f
    public GameObject reward;
    public GameObject rewardmodel;
    private GameObject rmodel;
    public int cost = 10;

    void Start()
    {
        //Check if prereqs have been set, instantiate preview model
        if(rewardmodel == null || reward ==null)
        {
            Debug.Log("Reward not set at gameobject"+this.name);
        }

        Instantiate(rewardmodel, this.transform.position+Vector3.forward, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")&&Input.GetKeyDown(KeyCode.F)&&other.GetComponent<Money>().playermoney>=cost)
        {
            Instantiate(reward, other.transform.position, Quaternion.identity);
            other.GetComponent<Money>().updatemoney(-cost);
        }
    }
}
