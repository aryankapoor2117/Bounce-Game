using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    private Transform player;
    private Vector2 target;
    bool reflected = false;
    bool newPosSet = false;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (reflected == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyProjectile();
            }
        }
        else if (reflected==true)
        {
            if(newPosSet==false)
            {
                newPosSet = true;
                target = new Vector2(transform.position.x, transform.position.y);
                GetComponent<Rigidbody2D>().velocity =new Vector2(0, 0);
                Vector2 playerPos;
                Vector2 hitMarkerPos;
                playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
                hitMarkerPos = this.transform.position;
                //Debug.Log((hitMarkerPos - playerPos).x);
                GetComponent<Rigidbody2D>().velocity += new Vector2(((hitMarkerPos- playerPos  ).x*20), ((hitMarkerPos- playerPos ).y * 20));//new Vector2(20, 20);
                //Vector2 vVelocity = GetComponent<Rigidbody2D>().velocity;
                //vVelocity = -vVelocity;
                //GetComponent<Rigidbody2D>().velocity = vVelocity;
                // target.x = target.x - 100;
                //target.y = target.y - 100;

            }
           // transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
               // DestroyProjectile();
            }
        }

    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (reflected == false)
            {
                DestroyProjectile();
            }

            
        }
        else if (collision.CompareTag("Hitmarker"))
        {
            reflected = true;
           // Debug.Log("Bullet hit hitmarker");
        }
        else if(collision.CompareTag("Basic Enemy 1"))
        {
            if(reflected==true)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
