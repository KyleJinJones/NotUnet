using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{


    public Camera camera1;
    public Camera camera2;

    public bool isHorizontal = false;   


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            changeSplitScreen();  
        }       
    }

    public void changeSplitScreen() 
    {
        isHorizontal = !isHorizontal;

        if(isHorizontal) 
        {
            camera1.rect = new Rect(0, 0, 1, 0.5f);
            camera2.rect = new Rect(0, 0.5f, 1, 0.5f);            
        }
        else
        {
            camera1.rect = new Rect(0, 0, 0.5f, 1);
            camera2.rect = new Rect(0.5f ,0, 0.5f, 1);
        }
    }
}
