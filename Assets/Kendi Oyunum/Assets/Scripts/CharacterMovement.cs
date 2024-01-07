using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public VariableJoystick joystick;
    public Canvas inputCanvas;
    public bool isJoystick;
    public CharacterController controller;
    public float movementSpeed;

    private void Start()
    {
        EnableJoystickInput();
    }

    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);

    }

    private void Update()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector3(joystick.Direction.x,0.0f, joystick.Direction.y);
            controller.SimpleMove(movementDirection * movementSpeed);
        }
    }
}
