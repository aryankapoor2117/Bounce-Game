using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject enemy;
    private Rigidbody2D enemyBody;//= enemy.GetComponent<Rigidbody2D>;
    bool inChargePhase = true;
    bool preRamPhase = false;
    bool inRamPhase = false;
    bool inCoolPhase=false;
    bool direction; //left==true, right ==false
    float timeElapsed=0.0f;
    float chargeUpTime = 2.0f;

    float coolTimeElapsed = 0.0f;
    float coolDownTime = 4.0f;


    public GameObject player;

    //Vector2 playerPos = player.GetComponent
    void Start()
    {
        enemyBody.velocity = new Vector2(100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * 1);
        
        if (inChargePhase == true)
        {
            Vector3 targetPos;
            if (this.transform.position.x > 1.0f)
            {
                targetPos = new Vector3(this.transform.position.x - 0.2f, this.transform.position.y,-5.0f);
                direction = true;
            }
            else
            {
                targetPos = new Vector3(this.transform.position.x + 0.2f, this.transform.position.y,-5.0f);
                direction = false;
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, Time.deltaTime * 1);

            if ((direction == true && targetPos.x <= 9.0f)||(direction==false && targetPos.x>=-9.0f))
            {
                inChargePhase = false;
                preRamPhase = true;
            }
        }
        else if (preRamPhase==true)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed>=chargeUpTime)
            {
                preRamPhase = false;
                inRamPhase = true;
                timeElapsed = 0.0f;
            }
        }
        else if(inRamPhase==true)
        {
            //this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * 1);
            if(direction==true)
            {
                Vector3 targetPos;
                targetPos = new Vector3(-12.0f, this.transform.position.y,-5.0f);
                this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, Time.deltaTime * 6);
            }
            else if (direction == false)
            {
                Vector3 targetPos;
                targetPos = new Vector3(12.0f, this.transform.position.y,-5.0f);
                this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, Time.deltaTime * 6);
            }

            if(direction==true && this.transform.position.x<=-12.0f)
            {
                inRamPhase = false;
                inCoolPhase = true;
            }
            else if (direction==false && this.transform.position.x>=12.0f)
            {
                inRamPhase = false;
                inCoolPhase = true;
            }
        }
        else if(inCoolPhase==true)
        {
            //this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * 1);
            coolTimeElapsed += Time.deltaTime;
            if (coolTimeElapsed >= coolDownTime)
            {
                direction = !direction;
                inCoolPhase = false;
                inChargePhase = true;
                coolTimeElapsed = 0.0f;
            }
        }
       // Debug.Log(this.transform.position.z);

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
