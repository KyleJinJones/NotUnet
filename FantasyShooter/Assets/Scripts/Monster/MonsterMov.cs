using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMov : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject player;
    private Rigidbody rb;
    private Animator an;
    public float attackdist = 1.0f;
    public bool dead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player == null)
        {
            Debug.Log("PLAYER NOT SET");
        }
        else if(!dead)
        {
            Vector3 dir = player.transform.position- transform.position;
            dir.y = 0;
            an.SetBool("Close", false);
            if (dir.x + dir.z < attackdist)
            {
                an.SetBool("Close",true);
            }
            

            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = rot;
            
            dir.Normalize();
            
            dir *= speed;
            dir.y += rb.velocity.y;
            rb.velocity = dir;
            
            
        }
    
    }

    public IEnumerator Dead()
    {
        dead = true;
        an.SetBool("Dead", true);
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
