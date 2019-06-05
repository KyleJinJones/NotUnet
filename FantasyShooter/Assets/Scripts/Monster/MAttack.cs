using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAttack : MonoBehaviour
{
    public int dmgamt;
    public bool attacking = false;
    public bool isdead = false;
    public int totalframes = 30;
    public int attackstartframe = 7;
    private int timer = 0;
    private bool hit = false;

    //Total frames refers to the total frames in the attack animation
    //attack start frame refers to the frame at which the attack actually starts
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            timer += 1;
        }
        if (timer == totalframes + 1)
        {
            timer = 0;
            attacking = false;
            hit = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attacking && !hit && other.CompareTag("Player")&& vp_DamageHandler.GetDamageHandlerOfCollider(other) != null && timer>=attackstartframe)
        {
            hit = true;
            vp_DamageHandler.GetDamageHandlerOfCollider(other).Damage(new vp_DamageInfo(dmgamt,null));
        }
    }
}
