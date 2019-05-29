using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testscript : MonoBehaviour
{
    // Simulates a press of 1, causes the player to pull out their starting pistol.
    void Start()
    {
       GetComponent<vp_FPInput>().FPPlayer.SetWeapon.TryStart(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
