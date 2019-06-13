using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Transform Player;
    public float dmgamt;
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if(vp_DamageHandler.GetDamageHandlerOfCollider(collision.collider) != null&&!collision.collider.CompareTag("Player"))
        {
            vp_DamageHandler.GetDamageHandlerOfCollider(collision.collider).Damage(new vp_DamageInfo(dmgamt,GameObjectManager.player1.transform));
        }

    }
}
