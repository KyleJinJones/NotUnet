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
    public GameObject player2;
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
        player = GameObjectManager.player1;
        player2 = GameObjectManager.player2;
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
            //initSpawnPoints(enemiesToSpawn);
            spawnEnemies(enemiesToSpawn);

            enemiesLeft -= enemiesToSpawn;
            timer = spawnRate;
        }

        if(enemiesLeft == 0) {stopSpawning = true;}
    }

    public void spawnEnemies(int numOfEnemies)
    {
        GameObject targetplayer;
        for (int i = numOfEnemies - 1; i >= 0; --i)
        {
            if (Random.Range(1, 3) ==1)
            {
                targetplayer = player;
            }
            else
            {
                targetplayer = player2;
            }
            initSpawnPoints(1, targetplayer);
            GameObject temp =Instantiate(enemy, spawnPoints[0], Quaternion.identity);
            temp.GetComponent<MonsterMov>().player = targetplayer;
            enemies.Add(temp);
            
        }
    }

    public void initSpawnPoints(int length, GameObject targetplayer)
    {
        spawnPoints = new Vector3[length];

        for(int i = 0; i < length; ++i)
        {
            Vector3 randomPoint = new Vector3(randfloat(targetplayer.transform.position.x), 1.3f, randfloat(targetplayer.transform.position.z));
           // Debug.Log(randomPoint);
            spawnPoints[i] = randomPoint;
        }

    }

    private float randfloat(float playerpos)
    {
        int i = Random.Range(0, 2);
        float output = Random.Range(mindist, maxdist);

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
