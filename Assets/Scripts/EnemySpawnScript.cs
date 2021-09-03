using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject enemy;
    public GameObject sniper;
    public GameObject player;
    public GameObject ram;
    int maxRamCnt = 2;
    static int  currRamCnt = 0;
    float randX;
    float randY;
    Vector2 spawnPos;
    public float spawnRate = 2.2f;//0.7f;
    float spr = 2.2f;
    float nextSpawn = 0.0f;
    public static GameObject[] enemyArray;
    public static int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time>nextSpawn)
        {
            nextSpawn = Time.time + spr;//spawnRate;
            randX = Random.Range(-9.0f, 9.0f);
            randY = Random.Range(-5.0f, 5.0f);

            if (Mathf.Abs(randX - player.transform.position.x) < 3.0f)
            {
                randX += 1.5f;
            }
            if (Mathf.Abs(randY - player.transform.position.y) < 3.0f)
            {
                randY += 1.5f;
            }
            spawnPos = new Vector2(randX,randY);
            enemyCount++;
            Debug.Log(enemyCount);

            float enemyType = Random.Range(0.0f, 3.0f);
            if (enemyType >= 0.0f && enemyType < 1.5f)
            {
                enemyArray[enemyCount] = Instantiate(enemy, new Vector3(randX, randY, -5.0f), Quaternion.identity) as GameObject; 
                
            }
            else if (enemyType >= 1.5f && enemyType < 2.7f)
            {
                // Debug.Log("Spawning sniper");
                enemyArray[enemyCount] = Instantiate(sniper, new Vector3(randX, randY, -5.0f), Quaternion.identity) as GameObject;
            }
            else
            {
               // Debug.Log("Spawning ram");
                float leftOrRight = Random.Range(0.0f, 1.0f);
                if (currRamCnt < maxRamCnt)
                {
                    if (leftOrRight < 0.5f)
                    {
                        enemyArray[enemyCount] = Instantiate(ram, new Vector3(10.0f, randY, -5.0f), Quaternion.identity) as GameObject;
                        currRamCnt++;
                    }
                    else
                    {
                        enemyArray[enemyCount] = Instantiate(ram, new Vector3(-10.0f, randY, -5.0f), Quaternion.identity) as GameObject;
                        currRamCnt++;
                    }
                    
                    //Debug.Log("ram count ="+currRamCnt);
                }
            }
        }
        if(spr>0.2f)
        {
            spr -= Time.deltaTime * 0.01f;
           // Debug.Log(spr);
        }
    }

    public static void DecrementRamCnt()
    {
        currRamCnt--;
    }

   
}
