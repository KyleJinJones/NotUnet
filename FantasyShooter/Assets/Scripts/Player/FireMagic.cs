using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FireMagic : MonoBehaviour
{
    public GameObject effect;
    public float timer = 1.0f;
    private float basetime;
    public Image i;
    public TextMeshProUGUI timertext;
    private bool player1;

    void Start()
    {
        player1 = !this.GetComponentInParent<vp_FPInput>().player2;
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
            i.fillAmount = timer / basetime;
        }


        if (player1 && (Input.GetKeyDown(KeyCode.Mouse2)||Input.GetKeyDown(KeyCode.Joystick1Button5))&&timer>=basetime)
        {
           GameObject temp = Instantiate(effect, this.transform.position, this.transform.rotation);
            temp.GetComponentInChildren<Damage>().Player = GameObjectManager.player1.transform;
            temp.transform.Translate(.5f, 0, 0);
            timer = 0;
            
        }

        else if (!player1 && Input.GetAxisRaw("Magic2") == 1)
        {
           
            GameObject temp = Instantiate(effect, this.transform.position, this.transform.rotation);
            temp.GetComponentInChildren<Damage>().Player = GameObjectManager.player2.transform;
            temp.transform.Translate(.5f, 0, 0);
            timer = 0;
        }
        

        
        timertext.text = string.Format("{0:0.00}", timer);
    }
}
