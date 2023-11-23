using Assets.Scripts.Classes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private Rigidbody2D playerRigidBody;
    private PlayerClass player;
    private Vector2 moveInput;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Get the animator of the player
        animator = GetComponent<Animator>();

        //Get the Body of the player
        playerRigidBody = GetComponent<Rigidbody2D>();

        //Get the spriteRenderer of the player
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Set up player speed
        player = GetComponent<PlayerClass>();
        player.Speed = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        speed = GetComponent<PlayerClass>().Speed;
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        animator.SetFloat("Speed",speed);
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);


        if (moveInput.x == 0 && moveInput.y == 0)
        {
            player.Speed = 0;
        }
        else
        {
            player.Speed = 1;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        bool isMovingHorizontal = Mathf.Abs(horizontal) > 0.5f;
        bool isMovingVertical = Mathf.Abs(vertical) > 0.5f;


        if (isMovingVertical)
        {
            animator.SetFloat("Vertical", moveInput.y);
            playerRigidBody.velocity = new Vector2(0, vertical * speed);
        }
        else if (isMovingHorizontal)
        {
            animator.SetFloat("Horizontal", moveInput.x);
            playerRigidBody.velocity = new Vector2(horizontal * speed, 0);
        }
        else
        {
            playerRigidBody.velocity = Vector2.zero;
        }
        
    }
}
