using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections.Specialized;
using System.Diagnostics;

public class CarController : MonoBehaviour
{
    public float FirstLane;
    public float SecondLane;
    public float SmoothMove = 0.2f;

    bool rotateLeft = false;
    bool rotateRight = false;
    public float rotationSmoothSpeed = 0.2f;
    public float rotationDegree = 25f;

    public void ChangeLane()
    {
        if (transform.position.x == FirstLane)
        {
            transform.DOMoveX(SecondLane, SmoothMove).OnStart(RotateRight).OnComplete(RotateRight);

        }
        else if (transform.position.x == SecondLane)
        {
            transform.DOMoveX(FirstLane, SmoothMove).OnStart(RotateLeft).OnComplete(RotateLeft);
        }
    }

    public void RotateLeft()
    {
        if (rotateLeft)
        {
            transform.DORotate(new Vector3(0, 0, 0), rotationSmoothSpeed);
            rotateLeft = false;
        }
        else
        {
            transform.DORotate(new Vector3(0, 0, rotationDegree), rotationSmoothSpeed);
            rotateLeft = true;
        }
    }
    public void RotateRight()
    {
        if (rotateRight)
        {
            transform.DORotate(new Vector3(0, 0, 0), rotationSmoothSpeed);
            rotateRight = false;
        }
        else
        {
            transform.DORotate(new Vector3(0, 0, -rotationDegree), rotationSmoothSpeed);
            rotateRight = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Score")
        {
            GameManager.Instance.scoreIndex++;
            GameManager.Instance.scoreText.text = GameManager.Instance.scoreIndex.ToString();
            if (coll.gameObject != null)
            {
                Destroy(coll.gameObject);
            }
        }
        else if (coll.gameObject.tag == "GameOver" || coll.gameObject.tag == "CircleTrigger")
        {

            FindObjectOfType<GameManager>().GameOver();

        }

    }




}