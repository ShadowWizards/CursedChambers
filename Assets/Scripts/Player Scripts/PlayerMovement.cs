using Assets.Scripts.Classes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed;
    private Rigidbody2D _playerRigidBody;
    private Player _player;
    private Vector2 _moveInput;
    private Vector2 _playerXVelocity;
    private Vector2 _playerYVelocity;
    private Animator _animator;
    private KeyCode _lastKeyPressed;
    private float _actualSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Get the animator of the player
        _animator = GetComponent<Animator>();

        // Get the Body of the player
        _playerRigidBody = GetComponent<Rigidbody2D>();

        // actualSpeed is the default speed which is equal to 1 for now
        // and player Speed is the speed that the player is given by default or by buffs
        _player = GetComponent<Player>();
        _actualSpeed = 1 + _player.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        _moveInput.Normalize();
        _animator.SetFloat("Speed",_actualSpeed);
        _animator.SetFloat("Horizontal", _moveInput.x);
        _animator.SetFloat("Vertical", _moveInput.y);

        // Get last key pressed by the user
        if (Input.GetKeyDown(KeyCode.D))
        {
            _lastKeyPressed = KeyCode.D;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _lastKeyPressed = KeyCode.A;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _lastKeyPressed = KeyCode.W;

        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            _lastKeyPressed = KeyCode.S;
        }

        // // Set player speed
        if (_moveInput.x == 0 && _moveInput.y == 0)
        {
            _actualSpeed = 0;
        }
        else
        {
            _actualSpeed = 1 + _player.Speed;
        }
        
        // Change player sprite drawing direction and taking into consideration the player attack sprite
        if (_moveInput.x < 0)
        {
            if (Time.time >= _player.playerCooldown || _player.playerCooldown == 0)
            {
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }
        else if(_moveInput.x > 0)
        {
            if (Time.time >= _player.playerCooldown || _player.playerCooldown == 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            
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
        _playerXVelocity = new Vector2(horizontal * _actualSpeed, 0);
        _playerYVelocity = new Vector2(0, vertical * _actualSpeed);

        // In case two buttons are pressed at the same time set priority of movement to the last key pressed
        if (isMovingHorizontal && isMovingVertical)
        {
            switch (_lastKeyPressed)
            {
                case KeyCode.W:
                    _playerRigidBody.velocity = _playerYVelocity;
                    break;
                case KeyCode.S:
                    _playerRigidBody.velocity = _playerYVelocity;
                    break;
                case KeyCode.D:
                    _playerRigidBody.velocity = _playerXVelocity;
                    break;
                case KeyCode.A:
                    _playerRigidBody.velocity = _playerXVelocity;
                    break;
            }
        }
        // If moving on the vertical input axis
        else if (isMovingVertical)
        {
            _animator.SetFloat("Vertical", _moveInput.y);
            _playerRigidBody.velocity = _playerYVelocity;
        }
        // If moving on the horizontal input axis
        else if (isMovingHorizontal)
        {
            _animator.SetFloat("Horizontal", _moveInput.x);
            _playerRigidBody.velocity = _playerXVelocity;
        }
        else
        {
            _playerRigidBody.velocity = Vector2.zero;
        }
    }
}
