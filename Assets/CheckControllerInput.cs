using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckControllerInput : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        var gamePad = Gamepad.current;
        if (gamePad != null)
        {
            InputSystem.DisableDevice(Mouse.current);
        }
        else
        {
            InputSystem.EnableDevice(Mouse.current);
        }
    }
}
