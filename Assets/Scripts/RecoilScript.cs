using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilScript : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Basic Enemy 1"))
            {
            Vector2 forceToAdd = player.GetComponent<Rigidbody2D>().velocity;//player.transform.position - collision.transform.position;
            player.GetComponent<Rigidbody2D>().AddForce(-forceToAdd * 50);
        }
    }
}
