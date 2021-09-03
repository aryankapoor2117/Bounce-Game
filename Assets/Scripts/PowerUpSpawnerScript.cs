using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject powerUp;
    public GameObject bomb;
    public GameObject health;
    float randX;
    float randY;
    Vector2 spawnPos;
    public float spawnRate = 10.0f;
    float nextSpawn = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-9.0f, 9.0f);
            randY = Random.Range(-5.0f, 5.0f);
            float powerUpType = Random.RandomRange(0.0f, 1.0f);
            
                if (Mathf.Abs(randX - player.transform.position.x) < 0.5)
                {
                    randX += 1.0f;
                }
                if (Mathf.Abs(randY - player.transform.position.y) < 0.5)
                {
                    randY += 1.0f;
                }
                spawnPos = new Vector2(randX, randY);
            if (powerUpType < 0.3f)
            {
                Instantiate(powerUp, spawnPos, Quaternion.identity);
            }
            else if(powerUpType>=0.3f &&powerUpType<0.6f)
            {
                Instantiate(bomb, spawnPos, Quaternion.identity);
            }
            else
            {
                Instantiate(health, spawnPos, Quaternion.identity);
            }
           
        }
    }
}
