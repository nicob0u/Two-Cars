using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections.Specialized;
using System.Diagnostics;
using System;

public class CarController : MonoBehaviour
{
    public float FirstLane;
    public float SecondLane;
    public float SmoothMove = 0.2f;
    public float rotationSmoothSpeed = 0.2f;
    public float rotationDegree = 25f;

    private float currentTargetX;

    private Tween moveTween;
    private Tween rotateTween;

    public GameObject explosionFX;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Start()
    {
        currentTargetX = transform.position.x;
    }

    public void ChangeLane()
    {

        float newTargerX;
        if (Math.Abs(currentTargetX - FirstLane) < 0.01f)
        {
            newTargerX = SecondLane;
            RotateRight();
        }
        else
        {
            newTargerX = FirstLane;
            RotateLeft();
        }

        currentTargetX = newTargerX;

        if (moveTween != null && moveTween.IsActive())
        {
            moveTween.Kill();
        }
        moveTween = transform.DOMoveX(currentTargetX, SmoothMove).SetEase(Ease.Linear);
    }

    public void RotateLeft()
    {
        if (rotateTween != null && rotateTween.IsActive())
        {
            rotateTween.Kill();
        }
        rotateTween = transform.DORotate(new Vector3(0, 0, rotationDegree), rotationSmoothSpeed)
             .OnComplete(() =>
             {
                 transform.DORotate(Vector3.zero, rotationSmoothSpeed);


             });
    }
    public void RotateRight()
    {
        if (rotateTween != null && rotateTween.IsActive())
        {
            rotateTween.Kill();
        }
        rotateTween = transform.DORotate(new Vector3(0, 0, -rotationDegree), rotationSmoothSpeed)
             .OnComplete(() =>
             {
                 transform.DORotate(Vector3.zero, rotationSmoothSpeed);


             });
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Score")
        {

            if (explosionFX != null)
            {
                GameObject explosion = Instantiate(explosionFX, coll.transform.position, Quaternion.identity);
                Destroy(explosion, 1f);
            }

            audioManager.PlaySFX(audioManager.score);
            GameManager.Instance.scoreIndex++;
            GameManager.Instance.scoreText.text = GameManager.Instance.scoreIndex.ToString();

            if (coll.gameObject != null)
            {
                Destroy(coll.gameObject);
            }

        }
        else if (coll.gameObject.tag == "GameOver" || coll.gameObject.tag == "CircleTrigger")
        {
            audioManager.PlaySFX(audioManager.gameOver);
            FindObjectOfType<GameManager>().GameOver();

        }

    }




}