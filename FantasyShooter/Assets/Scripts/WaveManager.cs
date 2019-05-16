using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy; // Enemy prefab
    [SerializeField] private int enemiesLeft;
    [SerializeField] private int enemiesToSpawn;
    [SerializeField] private float spawnRate;   // per seconds

    private Vector3[] spawnPoints;
    [SerializeField] private float timer;

    private bool stopSpawning;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnRate; 
        stopSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(!stopSpawning) {timer -= Time.deltaTime;}

        if(timer <= 0 )
        {
            initSpawnPoints(enemiesToSpawn);
            Debug.Log("b");
            spawnEnemies(enemiesToSpawn);

            enemiesLeft -= enemiesToSpawn;
            timer = spawnRate;
        }

        if(enemiesLeft == 0) {stopSpawning = true;}
    }

    public void spawnEnemies(int numOfEnemies)
    {
        for (int i = numOfEnemies - 1; i >= 0; --i)
        {
            Instantiate(enemy, spawnPoints[i], Quaternion.identity);
        }
    }

    public void initSpawnPoints(int length)
    {
        spawnPoints = new Vector3[length];

        for(int i = 0; i < length; ++i)
        {
            Vector3 randomPoint = new Vector3(Random.Range(-5, 5), 1.3f, Random.Range(-5, 5));
            spawnPoints[i] = randomPoint;
        }

    }
}
