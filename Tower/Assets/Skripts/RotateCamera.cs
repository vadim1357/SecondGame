using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speed = 5f;
    Transform rotator;
   
    void Start()
    {
        rotator = GetComponent<Transform>();
    }

    
    void Update()
    {
        rotator.Rotate(0, speed * Time.deltaTime, 0);
    }
}
