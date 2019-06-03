using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(vp_DamageHandler.GetDamageHandlerOfCollider(collision.collider) != null&&!collision.collider.CompareTag("Player"))
        {
            vp_DamageHandler.GetDamageHandlerOfCollider(collision.collider).Damage(new vp_DamageInfo(1.0f, this.transform));
        }

    }
}
