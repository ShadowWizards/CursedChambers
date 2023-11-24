using Assets.Scripts.Classes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private Rigidbody2D playerRigidBody;
    private PlayerClass player;
    private Vector2 moveInput;
    private Vector2 playerXVelocity;
    private Vector2 playerYVelocity;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private KeyCode lastKeyPressed;
    private float actualSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Get the animator of the player
        animator = GetComponent<Animator>();

        // Get the Body of the player
        playerRigidBody = GetComponent<Rigidbody2D>();

        // Get the spriteRenderer of the player
        spriteRenderer = GetComponent<SpriteRenderer>();


        // actualSpeed is the default speed which is equal to 1 for now
        // and player Speed is the speed that the player is given by default or by buffs
        player = GetComponent<PlayerClass>();
        actualSpeed = 1 + player.Speed;

    }

    // Update is called once per frame
    void Update()
    {
        speed = GetComponent<PlayerClass>().Speed;
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        animator.SetFloat("Speed",actualSpeed);
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);

       //animator.SetBool("isWorUpPressed", Input.GetKey(KeyCode.UpArrow));
       //animator.SetBool("isAorLeftPressed", Input.GetKey(KeyCode.LeftArrow));
       //animator.SetBool("isSorDownPressed", Input.GetKey(KeyCode.DownArrow));
       //animator.SetBool("isDorRightPressed", Input.GetKey(KeyCode.RightArrow));

        animator.SetBool("isWorUpPressed", Input.GetKey(KeyCode.W));
        animator.SetBool("isAorLeftPressed", Input.GetKey(KeyCode.A));
        animator.SetBool("isSorDownPressed", Input.GetKey(KeyCode.S));
        animator.SetBool("isDorRightPressed", Input.GetKey(KeyCode.D));


        // Get last key pressed by the user

        if (Input.GetKeyDown(KeyCode.D))
        {
            lastKeyPressed = KeyCode.D;
            animator.SetInteger("lastKeyPressed", 3);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastKeyPressed = KeyCode.A;
            animator.SetInteger("lastKeyPressed", 4);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            lastKeyPressed = KeyCode.W;
            animator.SetInteger("lastKeyPressed", 1);

        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            lastKeyPressed = KeyCode.S;
            animator.SetInteger("lastKeyPressed", 2);

        }


        // Set player speed
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            actualSpeed = 0;
        }
        else
        {
            actualSpeed = 1 + player.Speed;
        }
        
        if (moveInput.x < 0.1)
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
    }

    private void FixedUpdate()
    {
        // horizontal and vertical are the current input Axis of the player
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Checks for wether current movement is on the horizontal or vertical axiss
        bool isMovingHorizontal = Mathf.Abs(horizontal) > 0.5f;
        bool isMovingVertical = Mathf.Abs(vertical) > 0.5f;

        // the velocity that will be assigned to the player depending on which input axis they are
        playerXVelocity = new Vector2(horizontal * actualSpeed, 0);
        playerYVelocity = new Vector2(0, vertical * actualSpeed);


        // In case two buttons are pressed at the same time set priority of movement to the last key pressed
        if (isMovingHorizontal && isMovingVertical)
        {
            switch (lastKeyPressed)
            {
                case KeyCode.W:
                    playerRigidBody.velocity = playerYVelocity;
                    break;
                case KeyCode.S:
                    playerRigidBody.velocity = playerYVelocity;
                    break;
                case KeyCode.D:
                    playerRigidBody.velocity = playerXVelocity;
                    break;
                case KeyCode.A:
                    playerRigidBody.velocity = playerXVelocity;
                    break;
            }
        }
        // If moving on the vertical input axis
        else if (isMovingVertical)
        {
            animator.SetFloat("Vertical", moveInput.y);
            playerRigidBody.velocity = playerYVelocity;
        }
        // If moving on the horizontal input axis
        else if (isMovingHorizontal)
        {
            animator.SetFloat("Horizontal", moveInput.x);
            playerRigidBody.velocity = playerXVelocity;
        }
        else
        {
            playerRigidBody.velocity = Vector2.zero;
        }
        
    }
}
