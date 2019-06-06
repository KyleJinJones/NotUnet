using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FireMagic : MonoBehaviour
{
    public GameObject effect;
    public float timer= 1.0f;
    private float basetime;
    public Image i;
    public TextMeshProUGUI timertext;
   
    void Start()
    {
        basetime = timer;
    }

    
    void Update()
    {
        if (timer < basetime)
        {
            timer += Time.deltaTime;

            if (timer > basetime)
            {
                timer = basetime;
            }
            i.fillAmount = timer/basetime;
        }
        

        if (Input.GetKeyDown(KeyCode.Mouse2)&&timer>=basetime)
        {
           GameObject temp = Instantiate(effect, this.transform.position, this.transform.rotation);
            temp.transform.Translate(.5f, 0, 0);
            timer = 0;
            
        }
        timertext.text = string.Format("{0:0.00}", timer);
    }
}
