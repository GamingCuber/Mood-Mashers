using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D playerBody;
    private Vector2 movementVector;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;
	public PauseMenuManager pauseMenu;
    public InputAction playerControls;

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        // Creates a movement vector based on player input
        // OLD INPUT SYSTEM, LEFT FOR TESTING PURPOSES
        //movementVector.x = Input.GetAxisRaw("Horizontal");
        //movementVector.y = Input.GetAxisRaw("Vertical");

        // Creates a movement vector based on player input, new input system
        // To change controls, go to the Player object in inspector and go down to the player movement script
        movementVector = playerControls.ReadValue<Vector2>();

        // If the player isn't moving, plays idle animation
        if (movementVector.x == 0 && movementVector.y == 0)
        {
            playerAnimator.SetBool("isMoving", false);
        }
        // If the player is moving, then plays walking animation
        else
        {
            if (movementVector.x >= 0)
            {
                playerRenderer.flipX = true;
            }
            else
            {
                playerRenderer.flipX = false;
            }
            playerAnimator.SetBool("isMoving", true);
        }
    }

    void FixedUpdate()
    {
        if (!pauseMenu.isPaused)
        {
            // Normalizes movement vector, preventing faster movement when moving diagonally
            if (movementVector.magnitude > 1)
            {
                movementVector = movementVector.normalized;
            }
            playerBody.MovePosition(playerBody.position + movementSpeed * Time.fixedDeltaTime * movementVector);
        }

    }
}




