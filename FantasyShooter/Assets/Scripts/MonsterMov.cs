using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMov : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject player;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.Log("PLAYER NOT SET");
        }
        else
        {
            Vector3 dir = player.transform.position- transform.position;
            dir.y = 0;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = rot;
            
            dir.Normalize();
            
            dir *= speed;
            dir.y += rb.velocity.y;
            rb.velocity = dir;
            
        }
    }
}
