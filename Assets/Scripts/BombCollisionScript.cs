using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollisionScript : MonoBehaviour
{

    public GameObject player;
   public static bool isPlaced = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (this.gameObject.tag != "PlacedBomb")
            {
            if (collision.gameObject.name == "Player Placeholder")
            {
                if (this.gameObject.tag != "PlacedBomb")
                {
                    PlayerMovementScript.incrementBombs();
                    //Debug.Log("Bomb cnt = " + PlayerMovementScript.bombCnt);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Ram"))
       // else if ((this.transform.position.x-collision.gameObject.transform.position.x<0.5)&& (this.transform.position.y - collision.gameObject.transform.position.y < 0.5))
        {
            
            if (this.gameObject.CompareTag("PlacedBomb"))
            {
               // Destroy(collision.gameObject);
                //Debug.Log("HIT RAM");
                Destroy(this.gameObject);
            }
        }
    }

    void Awake()
    {
        player = GameObject.Find("Player Placeholder");
    }

    public static void placeBomb()
    {
        isPlaced = true;
    }
}
