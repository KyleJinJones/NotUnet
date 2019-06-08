using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    [SerializeField] private float killtimer=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        killtimer -= Time.deltaTime;
        if (killtimer < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
