using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class PlayerAttackAnimator : MonoBehaviour
{
    public GameObject slash;
    private Player _player;
    private Animator _slashAnimator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _slashAnimator = slash.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the correct key is pressed down and executes the appropriate change to the player or slash sprites
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioMenager.Instance.playSFX("Attack");
            _slashAnimator.SetBool("isAttacking",true);
            
            _player.playerCooldown = Time.time + (float)0.40;
            transform.localRotation = Quaternion.Euler(0,0,0);
            slash.transform.localPosition = new Vector2((float)0.86,(float)-0.04);
            slash.transform.localRotation = Quaternion.Euler(0,0,(float)0.545);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioMenager.Instance.playSFX("Attack");
            _slashAnimator.SetBool("isAttacking",true);

            _player.playerCooldown = Time.time + (float)0.40;
            transform.localRotation = Quaternion.Euler(0,180,0);
            slash.transform.localPosition = new Vector2((float)0.86,(float)-0.04);
            slash.transform.localRotation = Quaternion.Euler(0,0,(float)0.545);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioMenager.Instance.playSFX("Attack");
            _slashAnimator.SetBool("isAttacking",true);

            _player.playerCooldown = Time.time + (float)0.40;
            slash.transform.localRotation = Quaternion.Euler(0,180,90);
            slash.transform.localPosition = new Vector2((float)-0.07,(float)0.94);
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioMenager.Instance.playSFX("Attack");
            _slashAnimator.SetBool("isAttacking",true);
            
            _player.playerCooldown = Time.time + (float)0.40;
            slash.transform.localRotation = Quaternion.Euler(0,0,270);
            slash.transform.localPosition = new Vector2((float)0.03,(float)-0.94);
        }
        else
        {
            _slashAnimator.SetBool("isAttacking",false);
        }
    }
}
