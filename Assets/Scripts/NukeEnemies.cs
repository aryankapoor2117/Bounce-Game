using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NukeEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Nuke()
    {
        //Array.Clear(EnemySpawnScript.enemyArray, 0, EnemySpawnScript.enemyArray.Length);
        //Debug.Log("Hello");
        //for (int i = 0; i < EnemySpawnScript.enemyCount; i++)
        //{
        //    EnemySpawnScript.enemyArray[i].GetComponent<CollisionScript>().KillMyself();

        //   // Destroy(EnemySpawnScript.enemyArray[i]);
        //    Debug.Log("Destroying");
        //}

        var clones = GameObject.FindGameObjectsWithTag("Basic Enemy 1");
        foreach (var clone in clones)
        {
            PlayerMovementScript.comboTime = 5.0f;
            PlayerMovementScript.currentCounter++;
            ScoreScript.scoreValue += PlayerMovementScript.currentMultiplier;
            Destroy(clone);
        }
        EnemySpawnScript.enemyCount = 0;
    }
}
