using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWeaponLayer : MonoBehaviour
{
    //bool once = false;
    // Start is called before the first frame update
    public Camera weaponcam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weaponcam.cullingMask &= 1 << 19;
        weaponcam.cullingMask |= 1 << 19;


        foreach (Transform child in transform)
            {
                vp_Layer.Set(child.gameObject, 19,true);
            }
        this.enabled = false;
    }
}
