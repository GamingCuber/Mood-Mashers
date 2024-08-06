using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D playerBody;
    private Vector2 movementVector;
    public PauseMenuManager pauseMenu;

    void Update()
    {
        // Creates a movement vector based on player input
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (!pauseMenu.isPaused)
        {
            if (movementVector.magnitude > 1)
            {
                movementVector = movementVector.normalized;
            }
            playerBody.MovePosition(playerBody.position + movementSpeed * Time.fixedDeltaTime * movementVector);
        }
    }
}
