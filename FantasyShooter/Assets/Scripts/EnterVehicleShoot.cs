using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnterVehicleShoot : MonoBehaviour
{
    private bool inVehicle = false;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject seat;

    [SerializeField] private vp_Controller m_Component;
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            player = other.gameObject;
            m_Component = player.GetComponent<vp_Controller>();
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
                player.transform.parent = seat.transform;
                player.transform.position = seat.transform.position;     
                // m_Component.PhysicsGravityModifier = 0f;
            }
        }  
    }
    void Update()
    {

        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            inVehicle = false;
            player.transform.parent = null;    
            // m_Component.PhysicsGravityModifier = 0.2f;
        }
    }
}
