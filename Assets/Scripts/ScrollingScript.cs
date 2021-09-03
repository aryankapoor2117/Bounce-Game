using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    // Start is called before the first frame update

    float scrollSpeed = -0.5f;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       float newPos= Mathf.Repeat(Time.time * scrollSpeed, 20);
        startPos.z = 10;
        transform.position = startPos + Vector3.right * newPos;
    }
}
