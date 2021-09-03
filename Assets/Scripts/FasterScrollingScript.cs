using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterScrollingScript : MonoBehaviour
{

    float scrollSpeed = -1.0f;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 20);
        startPos.z = 0;
        transform.position = startPos + Vector3.right * newPos;
    }
}