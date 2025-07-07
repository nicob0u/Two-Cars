using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    public Transform Pos;
    public Transform Cam;

    void Update()
    {
        if((transform.position.y - Cam.position.y < -4.5))
        {
            transform.position = new Vector3(transform.position.x, Pos.position.y, 0f);
        }
    }


}
