using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i { 
        get {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i; 
        }
    }

    public Sprite Orange;
    public Sprite Grape;
    public Sprite Pineapple;
    public Sprite Peach;
    public Sprite Pitahaya;
    public Sprite Pepper;
    public Sprite FlaskGreen;
    public Sprite FlaskRed;
    public Sprite FlaskPurple;
    public Sprite FlaskOrange;
    public Sprite ArmourBrown;
    public Sprite ArmourSilver;
    public Sprite ArmourBlue;
    public Sprite ArmourYellow;
    public Sprite ArmourRed;
    public Sprite BootsBrown;
    public Sprite BootsSilver;
    public Sprite BootsBlue;
    public Sprite BootsYellow;
    public Sprite BootsRed;
    public Sprite GlovesBrown;
    public Sprite GlovesSilver;
    public Sprite GlovesYellow;
    public Sprite GlovesBlue;
    public Sprite GlovesRed;
    public Sprite HatBrown;
    public Sprite HatSilver;
    public Sprite HatBlue;
    public Sprite HatYellow;
    public Sprite HatRed;
    public Sprite HelmetBrown;
    public Sprite HelmetSilver;
    public Sprite HelmetBlue;
    public Sprite HelmetYellow;
    public Sprite HelmetRed;
    public Sprite SwordBrown;
    public Sprite SwordSilverAndYellow;
    public Sprite SwordSilverAndBlack;
    public Sprite SwordYellow;
    public Sprite SwordRed;
    public Sprite Error;
}