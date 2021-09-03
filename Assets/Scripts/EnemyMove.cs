using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject enemy;
    private Rigidbody2D enemyBody;//= enemy.GetComponent<Rigidbody2D>;
    

    public GameObject player;
    
    //Vector2 playerPos = player.GetComponent
    void Start()
    {
        enemyBody.velocity = new Vector2(100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * 1);
        
    }

    //void CollidedWithPlayer()
    //{
    //    if (player.transform.position.y >= this.transform.position.y)
    //    {
    //        Destroy(this);
    //    }

    //}

    void Awake()
    {
        player = GameObject.Find("Player Placeholder");
    }
}
