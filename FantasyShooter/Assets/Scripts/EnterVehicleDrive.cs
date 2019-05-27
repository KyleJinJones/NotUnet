using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnterVehicleDrive : MonoBehaviour
{
    private bool inVehicle = false;
    private CarUserControl vehicleScript;
    [SerializeField] private GameObject player;

    void Awake() {
        vehicleScript = GetComponent<CarUserControl>();
        vehicleScript.enabled = false;
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            if (Input.GetKey(KeyCode.G))
            {
                inVehicle = true;
                player.SetActive(false);
                player.transform.parent = gameObject.transform;              
                vehicleScript.enabled = true;
                
            }
        }  
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}
