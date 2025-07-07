using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public Transform[] Obstacles;
    public Transform[] Positions;
    public Transform CircleTrigger;
    public float minInsTime = 2f;
    public float maxInsTime = 3f;
    void Start()
    {
    
    StartCoroutine(SpawnObstaclesRoutine());
    }

    public IEnumerator SpawnObstaclesRoutine()
    {
        while (true)
        {
            float insTime = UnityEngine.Random.Range(minInsTime, maxInsTime);
            yield return new WaitForSeconds(insTime);

            int randPos = UnityEngine.Random.Range(0, 2);
            int randObs = UnityEngine.Random.Range(0, 2);

            Transform obs = Instantiate(Obstacles[randObs], Positions[randPos].position, Quaternion.identity);
            if (randObs == 0)
            {
               Transform circleTrigger = Instantiate(CircleTrigger, transform.position, Quaternion.identity);
                circleTrigger.SetParent(obs);
            }



        }
    }
}
