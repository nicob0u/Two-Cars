using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{

    void Update()
    {
       
            KeyboardInput();
            TouchInput();
        
    }

    public void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameManager.Instance.redCar.ChangeLane();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameManager.Instance.blueCar.ChangeLane();
        }
    }

    public void TouchInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    GameManager.Instance.redCar.ChangeLane();
                }
                else
                {
                    GameManager.Instance.blueCar.ChangeLane();
                }
            }
        }
    }
}
