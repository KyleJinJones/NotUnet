using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    private GameObject enemy; //hold the parent enemy object which holds hp values
    private vp_DamageHandler enemyDamageHandlerRef;
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.transform.parent.gameObject;
        if (enemy == null)
            Debug.Log("OH NO, there is no enemy reference");
        else
            enemyDamageHandlerRef = enemy.GetComponent<vp_DamageHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        //this should be a number between 0.0 - 1.0 to represent a percentage of health left
        float healthPercent =  enemyDamageHandlerRef.CurrentHealth / enemyDamageHandlerRef.MaxHealth;
        //scale the 3D health bar by a precentage, which is based on the current health of the parent
        this.transform.localScale = new Vector3(this.transform.localScale.x, healthPercent, this.transform.localScale.z);
        
        //remove health object when there is no health left on the parent object
        if (healthPercent <= 0.0)
            this.gameObject.SetActive(false);
    }
}
