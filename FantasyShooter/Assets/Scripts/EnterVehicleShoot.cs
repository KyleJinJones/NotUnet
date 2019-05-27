using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnterVehicleShoot : MonoBehaviour
{
    private bool inVehicle = false;
    [SerializeField] private GameObject player;
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            player = other.gameObject;
        }
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            if (Input.GetKey(KeyCode.G))
            {
                inVehicle = true; 
                player.transform.Translate(new Vector3(0f, 2f, 2f));          
                player.transform.parent = gameObject.transform;       
            }
        }  
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            inVehicle = false;
            player.transform.parent = null;       
        }
    }
}
