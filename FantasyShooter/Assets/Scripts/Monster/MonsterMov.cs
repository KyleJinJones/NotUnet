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
    public MAttack ma;
    [SerializeField] private GameObject powerup;
    [SerializeField] AudioClip Runloop;
    [SerializeField] AudioClip Attksound;
    [SerializeField] AudioSource asource;
    private float sfxtimer=1.0f;

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
        else if (dead)
        {

        }
        else
        {
            
            Vector3 dir = player.transform.position- transform.position;
            dir.y = 0;
            an.SetBool("Close", false);
            if (dir.x + dir.z < attackdist)
            {
                if (!asource.isPlaying&&sfxtimer<=0)
                {
                    sfxtimer = 1.0f;
                    asource.PlayOneShot(Attksound);
                }
                an.SetBool("Close",true);
                ma.attacking = true;
            }
            

            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = rot;
            
            dir.Normalize();
            
            dir *= speed;
            dir.y += rb.velocity.y;
            rb.velocity = dir;
            
            
        }
        sfxtimer -= Time.deltaTime;
    
    }

    public IEnumerator Dead()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        dead = true;
        an.SetBool("Dead", true);
        if (Random.Range(0, 10) == 3)
        {
            Instantiate(powerup, this.transform.position+Vector3.up, Quaternion.identity);
        }
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
