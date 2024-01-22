using Assets.Scripts.Classes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private Player _player;
    private Vector2 _moveInput;
    private Vector2 _moveDir;
    private Animator _animator;
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
        if (!_player.isAlive)
        {
            return;
        }
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        _moveInput.Normalize();
        _animator.SetFloat("Speed",_actualSpeed);
        _animator.SetFloat("Horizontal", _moveInput.x);
        _animator.SetFloat("Vertical", _moveInput.y);

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
        if (!_player.isAlive)
        {
            return;
        }
        // horizontal and vertical are the current input Axis of the player
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _moveDir = new Vector2(horizontal, vertical).normalized;

        _playerRigidBody.velocity = new Vector2(_moveDir.x * _actualSpeed, _moveDir.y * _actualSpeed);
    }
}
