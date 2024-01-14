using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string Slot;
    public ItemEnum ItemType;
    public bool IsHealing
    {
        get
        {
            switch (ItemType)
            {
                case ItemEnum.Orange:
                case ItemEnum.Grape:
                case ItemEnum.Pineapple:
                case ItemEnum.Peach:
                case ItemEnum.Pitahaya:
                case ItemEnum.Pepper:
                    return true;
                default:
                    return false;
            }
        }
    }

    public bool IsConsumableShield
    {
        get
        {
            switch (ItemType)
            {
               case ItemEnum.Pepper:
               case ItemEnum.FlaskOrange:
                   return true;
               default:
                   return false;
            }
        }
    }

    public bool GivesSpeed
    {
        get
        {
            switch (ItemType)
            {
                case ItemEnum.BootsBlue:
                case ItemEnum.BootsBrown:
                case ItemEnum.BootsSilver:
                case ItemEnum.BootsRed:
                case ItemEnum.BootsYellow:
                case ItemEnum.HatBrown:
                case ItemEnum.HatRed:
                case ItemEnum.HatSilver:
                case ItemEnum.HatYellow:
                case ItemEnum.HatBlue:
                    return true;
                default:
                    return false;
            }
        }
    }
    public enum ItemEnum {
       Orange,
       Grape,
       Pineapple,
       Peach,
       Pitahaya ,
       Pepper,
       FlaskGreen,
       FlaskRed,
       FlaskPurple,
       FlaskOrange,
       ArmourBrown,
       ArmourSilver,
       ArmourBlue,
       ArmourYellow,
       ArmourRed,
       BootsBrown,
       BootsSilver,
       BootsBlue,
       BootsYellow,
       BootsRed,
       GlovesBrown,
       GlovesSilver,
       GlovesBlue,
       GlovesYellow,
       GlovesRed,
       HatBrown,
       HatSilver,
       HatBlue,
       HatYellow,
       HatRed,
       HelmetBrown,
       HelmetSilver,
       HelmetBlue,
       HelmetYellow,
       HelmetRed,
       SwordBrown,
       SwordSilverAndYellow,
       SwordSilverAndBlack,
       SwordYellow,
       SwordRed,
       
    }

    public static int GetCost(ItemEnum itemType) {
        switch (itemType) {
        default:
        case ItemEnum.Orange:       return 10;
        case ItemEnum.Grape:       return 10;
        case ItemEnum.Pineapple:       return 20;
        case ItemEnum.Peach:       return 30;
        case ItemEnum.Pitahaya:       return 40;
        case ItemEnum.Pepper:       return 50;
        }
    }

    public static Sprite GetSprite(ItemEnum itemType) {
        switch (itemType) {
        default:
        case ItemEnum.Orange:       return GameAssets.i.Orange;
        case ItemEnum.Grape:        return GameAssets.i.Grape;
        case ItemEnum.Pineapple:       return GameAssets.i.Pineapple;
        case ItemEnum.Peach:       return GameAssets.i.Peach;
        case ItemEnum.Pitahaya:       return GameAssets.i.Pitahaya;
        case ItemEnum.Pepper:       return GameAssets.i.Pepper;
        }
    }

    public static float GetHp(ItemEnum itemType)
    {
        switch (itemType)
        {
            default:
            case ItemEnum.Orange: return 2;
            case ItemEnum.Grape: return 2;
            case ItemEnum.Pineapple: return 4;
            case ItemEnum.Peach: return 6;
            case ItemEnum.Pitahaya: return 12;
            case ItemEnum.Pepper: return 6;
            case ItemEnum.FlaskGreen: return 5;
            case ItemEnum.FlaskOrange: return 10;
            case ItemEnum.FlaskRed: return 10;
            case ItemEnum.FlaskPurple: return 6;
        }
    }

    public static float GetShield(ItemEnum itemType)
    {
        switch (itemType)
        {
            default:
            case ItemEnum.Pepper: return 5;
            case ItemEnum.FlaskOrange: return 5;
        }
    }

}
