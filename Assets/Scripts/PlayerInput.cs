using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
    KeyboardInput
}
public class PlayerInput : MonoBehaviour
{
   public InputType inputType = InputType.KeyboardInput;

    void Update()
    {
        if (inputType == InputType.KeyboardInput)
        {
            KeyboardInput();
        }
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
}
