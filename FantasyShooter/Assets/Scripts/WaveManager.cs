using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private int enemiesLeft;
    [SerializeField] private int enemiesToSpawn;
    [SerializeField] private float spawnRate;   // per seconds

    private Vector3[] spawnPoints;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnRate; // conver to seconds
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            initSpawnPoints(enemiesToSpawn);
            spawnEnemies(enemiesToSpawn);
        }
    }

    public void spawnEnemies(int numOfEnemies)
    {
        for (int i = numOfEnemies; i > 0; --i)
        {
            // enemy instantiation here
        }
    }

    public void initSpawnPoints(int length)
    {
        spawnPoints = new Vector3[length];

        //random generation goes here


        for(int i = 0; i < length; ++i)
        {
            Vector3 randomPoint = new Vector3(0, 0, 0);
            spawnPoints[i] = randomPoint;
        }

    }
}
