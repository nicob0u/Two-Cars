using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    public float startingSpeed = 5f;
    public float addedSpeed = 0.5f;
    private float speed;
    void Start()
    {
        speed = startingSpeed;
    }

    
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
        speed += addedSpeed * Time.deltaTime;
    }
}
