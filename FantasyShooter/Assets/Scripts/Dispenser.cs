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

    void Start()
    {
        //Check if prereqs have been set, instantiate preview model
        if(rewardmodel == null || reward ==null)
        {
            Debug.Log("Reward not set at gameobject"+this.name);
        }

        rmodel = Instantiate(rewardmodel, this.transform);
        rmodel.transform.position = rmodel.transform.position + Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")&&Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(reward, other.transform);
        }
    }
}
