using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hitMarker;
    public GameObject player;
    float orbitSpeed = 10.0f;
    float degree = 0.0f;
    public static float speed = 1.5f;
    float pauseTime = 0.0f;
    bool paused = false;
    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0.5f, 0,0);
        //hitMarker.transform.position = player.transform.position+offset;
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    speed = 6.0f;
        //    paused = true;
        //   // PlayerMovementScript.characterBody.transform.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

        //}
        //else
        //{
        //    speed = 1.5f;
        //    PlayerMovementScript.characterBody.transform.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        //}
        degree += Time.deltaTime*speed;
        float x = player.transform.position.x+Mathf.Cos(degree);
        float y = player.transform.position.y+Mathf.Sin(degree);
        hitMarker.transform.position = new Vector3(x, y, -5);
        if (paused == true)
        {
            pauseTime += Time.deltaTime;
            if(pauseTime>=0.75f)
            {
                speed = 1.5f;
                paused = false;
            }
        }
      // hitMarker.transform.RotateAround(player.transform.position, orbitSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 forceToAdd = player.transform.position - collision.transform.position;
        player.GetComponent<Rigidbody2D>().AddForce(forceToAdd*100);
    }
}
