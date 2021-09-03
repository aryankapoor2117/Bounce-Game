using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    public GameObject player;
    [SerializeField] int hitPoints;
    float hitCooldown = 0.5f;
    float timeElapsed = 0.5f;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (transform.position.y <= player.transform.position.y)
        //{
        //    Debug.Log("Hit");
        //    this.gameObject.SetActive(false);
        //}

        

        if (collision.gameObject.name == "HitMarker")
        {

            timeElapsed += Time.deltaTime;
            if (timeElapsed >= (hitCooldown))
            {
                Rigidbody2D playerBody = player.GetComponent<Rigidbody2D>();
                Vector2 playerVelocity = playerBody.velocity;
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f,1.0f));
                timeElapsed = 0.0f;
                //Debug.Log("Hit");
                hitPoints--;
                if (hitPoints <= 0)
                {
                    //this.gameObject.SetActive(false);
                    ScoreScript.scoreValue += ((PlayerMovementScript.currentMultiplier));
                    EnemySpawnScript.enemyCount--;
                    PlayerMovementScript.comboTime = 5.0f;
                    PlayerMovementScript.currentCounter++;
                    if (this.gameObject.CompareTag("Bullet"))
                    { }

                    else
                    {
                        if (this.gameObject.name == "Ram Enemy")
                        {
                            EnemySpawnScript.DecrementRamCnt();
                        }
                        Destroy(this.gameObject);
                    }
                }
            }
        }
        else if (collision.gameObject.name == "Player Placeholder")
        {
            //Debug.Log("Hit");
            //this.gameObject.SetActive(false);
            if (PlayerMovementScript.hitPoints <= 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                PlayerMovementScript.hitPoints = 10;
                EnemySpawnScript.enemyCount = 0;
                ScoreScript.scoreValue = 0;

            }
            else
            {
                hitPoints--;
                PlayerMovementScript.hitPoints--;
            }
            if (hitPoints <= 0)
            {
                Destroy(this.gameObject);
            }
            
            // Destroy(player);
        }
        else if (collision.gameObject.CompareTag("PlacedBomb"))
        {
            //Debug.Log("IN IF STATEMENT");
            if(this.gameObject.CompareTag("Ram"))
            {
                Debug.Log("HIT RAM");
                //Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    void Awake()
    {
        player = GameObject.Find("Player Placeholder");
    }

    public void KillMyself()
    {
        
        Destroy(this.gameObject);
    }

    
}
