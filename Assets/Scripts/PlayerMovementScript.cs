using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    
    public float upwardForce=0f;
    bool touched = false;
    bool editorTouched = false;

    public GameObject character;
    public GameObject bomb;
    public GameObject player;
    
    public static Rigidbody2D characterBody;
    float dashTime = 0.0f;
    bool dashing = false;
    float dashCooldown = 0.0f;
    bool canDash = true;

    public static float  comboTime = 5.0f;
    bool comboEnded = false;
   public static int currentCounter = 0;
    public static int currentMultiplier = 1;

    bool speedZone = false;

    public static int hitPoints = 10;

   public static int bombCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        characterBody = character.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey)
        {
            editorTouched = false;
        }

        if (Input.anyKey)
        {

            if (editorTouched == false)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
                {
                    if (speedZone == true)
                    {
                        HitMarkerMove.speed = 1.5f;
                        speedZone = false;
                    }
                    VerticalBounce(1.0f);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    if (speedZone == true)
                    {
                        HitMarkerMove.speed = 1.5f;
                        speedZone = false;
                    }
                    VerticalBounce(-1.0f);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    if (speedZone == true)
                    {
                        HitMarkerMove.speed = 1.5f;
                        speedZone = false;
                    }
                    if (canDash == true)
                    {
                        HorizontalBounce(1.0f);
                        dashTime = 0.0f;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
                {
                    if (speedZone == true)
                    {
                        HitMarkerMove.speed = 1.5f;
                        speedZone = false;
                    }
                    if (canDash == true)
                    {
                        HorizontalBounce(-1.0f);
                        dashTime = 0.0f;
                        
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    characterBody.velocity = Vector3.zero;
                    characterBody.transform.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                    HitMarkerMove.speed = 6.0f;
                    speedZone = true;
                }
                else if (Input.GetKeyDown(KeyCode.C))
                {
                    if (bombCnt != 0)
                    {
                        float randX;
                        float randY;
                        Vector3 spawnPos;
                        randX = Random.Range(-9.0f, 9.0f);
                        randY = Random.Range(-5.0f, 5.0f);
                        spawnPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                        Instantiate(bomb, spawnPos, Quaternion.identity);
                        bombCnt--;
                    }
                    else
                    {
                        Debug.Log("Not enough bombs");
                    }
                    
                }
                editorTouched = true;
            }

        }
        if (!Input.anyKey)
        {
            if (speedZone == true)
            {
                HitMarkerMove.speed = 1.5f;
                characterBody.transform.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                speedZone = false;
            }
        }

        if (dashing == true)
        {
            dashTime += Time.deltaTime;
        }

        if (dashTime >= 0.2f)
        {
            dashTime = 0.0f;
            dashing = false;
            // characterBody.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            characterBody.transform.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }

        if (canDash == false)
        {
            dashCooldown += Time.deltaTime;
            if (dashCooldown >= 0.3f)
            {
                canDash = true;
                dashCooldown = 0.0f;
            }
        }

        comboTime -= Time.deltaTime;
        //Debug.Log(currentCounter);
        if (comboTime <= 0.0f)
        {
            comboEnded = true;
            currentCounter = 0;
            currentMultiplier = 1;
        }

        if(currentCounter>=4&&currentMultiplier!=2)
        {
            //currentMultiplier *= 2+(Mathf.CeilToInt(ScoreScript.scoreValue / 10));
            currentMultiplier += (int)Time.deltaTime*4;
            Debug.Log(currentMultiplier);
        }


    }

    public static void incrementBombs()
    {
        bombCnt++;
    }    


//    void FixedUpdate()
//    {
//#if UNITY_EDITOR

//        //if (!Input.anyKey)
//        //{
//        //    editorTouched = false;
//        //}

//        //if (Input.anyKey)
//        //{

//        //    if (editorTouched == false)
//        //    {
//        //        if (Input.GetKey(KeyCode.UpArrow))
//        //        {
//        //            VerticalBounce(1.0f);
//        //        }
//        //        else if (Input.GetKey(KeyCode.DownArrow))
//        //        {
//        //            VerticalBounce(-1.0f);
//        //        }
//        //        else if (Input.GetKey(KeyCode.RightArrow))
//        //        {
//        //            HorizontalBounce(1.0f);
//        //            dashTime = 0.0f;
//        //        }
//        //        editorTouched = true;
//        //    }
            
//        //}
        
//        //if (Input.GetKey(KeyCode.UpArrow) && editorTouched== false)
//        //{
//        //    editorTouched = true;

//        //}
        
//#endif
//    }


    private void VerticalBounce(float VerticalInput)
    {
        characterBody.velocity = Vector3.zero;
        characterBody.AddForce(new Vector2(0, 450*VerticalInput)); 
    }

    private void HorizontalBounce(float HorizontalInput)
    {
        characterBody.velocity = Vector3.zero;
        
        dashing = true;
        //characterBody.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        characterBody.transform.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        characterBody.AddForce(new Vector2(200* HorizontalInput, 0));
        canDash = false;
    }

    void Awake()
    {
        player = GameObject.Find("Player Placeholder");
    }

}

