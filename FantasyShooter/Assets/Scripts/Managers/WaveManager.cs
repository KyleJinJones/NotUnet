using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy; // Enemy prefab
     private int baseenemiesleft; // Stored base value 
    [SerializeField] private int enemiesLeft;
    [SerializeField] private int enemiesToSpawn;
    [SerializeField] private float spawnRate;   // per seconds
    public GameObject player;
    public float mindist = 10.0f;
    public float maxdist = 30.0f;
    private Vector3[] spawnPoints;
    [SerializeField] private float timer;
    public List<GameObject> enemies;
    public GameObject dispensers;
    [SerializeField] private float incpercent=1.4f;//percent enemies increase by each round


    private bool stopSpawning;

    // Start is called before the first frame update
    void Start()
    {
        baseenemiesleft = enemiesLeft;
        dispensers = GameObjectManager.dispensers;
        player = GameObjectManager.player;
        timer = spawnRate; 
        stopSpawning = false;
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!stopSpawning) {timer -= Time.deltaTime;}
        //Checks if there are any enemies left, and then if there are none, then it turns itself off, brings back the dispensers and rests its enemycount
        else if(CheckEnemies())
        {
            enemies = new List<GameObject>();
            dispensers.SetActive(true);
            baseenemiesleft = (int)(baseenemiesleft * incpercent) ;
            enemiesLeft = baseenemiesleft;
            stopSpawning = false;
            this.enabled = false;

        }

        if(timer <= 0 )
        {
            initSpawnPoints(enemiesToSpawn);
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
            GameObject temp =Instantiate(enemy, spawnPoints[i], Quaternion.identity);
            temp.GetComponent<MonsterMov>().player = player;
            enemies.Add(temp);
            
        }
    }

    public void initSpawnPoints(int length)
    {
        spawnPoints = new Vector3[length];

        for(int i = 0; i < length; ++i)
        {
            Vector3 randomPoint = new Vector3(randfloat(player.transform.position.x), 1.3f, randfloat(player.transform.position.z));
            Debug.Log(randomPoint);
            spawnPoints[i] = randomPoint;
        }

    }

    private float randfloat(float playerpos)
    {
        int i = Random.Range(0, 2);
        float output = Random.Range(mindist, maxdist);
        print(i);
        if (i == 1)
        {
            return playerpos - output;
        }
        else
        {
            return playerpos + output;
        }
    }

    private bool CheckEnemies()
    {
        foreach (GameObject go in enemies)
        {
            if (go != null)
            {
                return false;
            }
        }
        return true;
    }
}
