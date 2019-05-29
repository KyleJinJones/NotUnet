using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagic : MonoBehaviour
{
    public GameObject effect;
    public float timer;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
           GameObject temp = Instantiate(effect, this.transform.position, this.transform.rotation);
            temp.transform.Translate(.5f, 0, 0);
            
        }
    }
}
