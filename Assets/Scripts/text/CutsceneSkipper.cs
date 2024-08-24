using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CutsceneSkipper : MonoBehaviour
{

    void Update()
    {
        var gamepad = Gamepad.current;
        if (Input.GetKeyDown(KeyCode.Space) || (gamepad != null && gamepad.startButton.wasPressedThisFrame))
        {
            SceneManager.LoadSceneAsync("TestScene");
        }
    }
}
