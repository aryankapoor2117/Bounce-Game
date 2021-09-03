using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player Placeholder")
        {
            HealthPickUp();
            Destroy(this.gameObject);
        }
    }

    public static void HealthPickUp()
    {
        int currHP = PlayerMovementScript.hitPoints;
        if (currHP <= 5)
        {
            currHP += 5;
        }
        else
        {
            currHP = 10;
        }
        PlayerMovementScript.hitPoints = currHP;

    }
}
