/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using UnityEngine;
using V_AnimationSystem;
using CodeMonkey.Utils;

/*
 * Player movement with Arrow keys
 * Attack with Space
 * */
public class PlayerSword : MonoBehaviour {
    
    public static PlayerSword instance;

    private const float SPEED = 50f;

    private PlayerMain playerMain;
    private Player_Base playerBase;
    private State state;
    private Material material;
    private Color materialTintColor;

    private enum State {
        Normal,
        Attacking,
    }

    private void Awake() {
        instance = this;
        playerMain = GetComponent<PlayerMain>();
        playerBase = gameObject.GetComponent<Player_Base>();
        material = transform.Find("Body").GetComponent<MeshRenderer>().material;
        materialTintColor = new Color(1, 0, 0, 0);
        SetStateNormal();
    }

    private void Update() {
        switch (state) {
        case State.Normal:
            HandleAttack();
            break;
        case State.Attacking:
            HandleAttack();
            break;
        }

        if (materialTintColor.a > 0) {
            float tintFadeSpeed = 6f;
            materialTintColor.a -= tintFadeSpeed * Time.deltaTime;
            material.SetColor("_Tint", materialTintColor);
        }
    }
    
    private void SetStateNormal() {
        state = State.Normal;
        playerMain.PlayerMovementHandler.Enable();
    }

    private void SetStateAttacking() {
        state = State.Attacking;
        playerMain.PlayerMovementHandler.Disable();
    }

    private void HandleAttack() {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            // Attack
            SetStateAttacking();

            //Vector3 attackDir = (UtilsClass.GetMouseWorldPosition() - GetPosition()).normalized;
            Vector3 attackDir = Vector3.zero;

            Enemy enemyHandler = Enemy.GetClosestEnemy(GetPosition() + attackDir * 4f, 20f);
            if (enemyHandler != null) {
                enemyHandler.Damage(Player.Instance);
                attackDir = (enemyHandler.GetPosition() - GetPosition()).normalized;
                transform.position = enemyHandler.GetPosition() + attackDir * -12f;

                if (enemyHandler.IsDead()) {
                    // Enemy Dead, get gold
                    int goldAmount = UnityEngine.Random.Range(10, 20);
                    DamagePopup.Create(GetPosition(), goldAmount, true);
                    Player.Instance.AddGoldAmount(goldAmount);
                }
            } else {
                transform.position = transform.position + attackDir * 4f;
            }

            Transform swordSlashTransform = Instantiate(GameAssets.i.pfSwordSlash, GetPosition() + attackDir * 13f, Quaternion.Euler(0, 0, UtilsClass.GetAngleFromVector(attackDir)));
            swordSlashTransform.GetComponent<SpriteAnimator>().onLoop = () => Destroy(swordSlashTransform.gameObject);

            UnitAnimType activeAnimType = playerBase.GetUnitAnimation().GetActiveAnimType();
            if (activeAnimType == GameAssets.UnitAnimTypeEnum.dSwordTwoHandedBack_Sword) {
                swordSlashTransform.localScale = new Vector3(swordSlashTransform.localScale.x, swordSlashTransform.localScale.y * -1, swordSlashTransform.localScale.z);
                playerBase.GetUnitAnimation().PlayAnimForced(GameAssets.UnitAnimTypeEnum.dSwordTwoHandedBack_Sword2, attackDir, 1f, (UnitAnim unitAnim) => SetStateNormal(), null, null);
            } else {
                playerBase.GetUnitAnimation().PlayAnimForced(GameAssets.UnitAnimTypeEnum.dSwordTwoHandedBack_Sword, attackDir, 1f, (UnitAnim unitAnim) => SetStateNormal(), null, null);
            }
        }
    }
    
    private void DamageFlash() {
        materialTintColor = new Color(1, 0, 0, 1f);
        material.SetColor("_Tint", materialTintColor);
    }

    public void DamageKnockback(Vector3 knockbackDir, float knockbackDistance) {
        transform.position += knockbackDir * knockbackDistance;
        DamageFlash();
    }
    public Vector3 GetPosition() {
        return transform.position;
    }
        
}
