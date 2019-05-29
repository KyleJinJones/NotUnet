using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<vp_FPInput>().FPPlayer.SetWeapon.TryStart(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
