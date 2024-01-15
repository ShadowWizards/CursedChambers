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
        case ItemEnum.ArmourBrown: return GameAssets.i.ArmourBrown;
        case ItemEnum.ArmourSilver: return GameAssets.i.ArmourSilver;
        case ItemEnum.ArmourBlue: return GameAssets.i.ArmourBlue;
        case ItemEnum.ArmourYellow: return GameAssets.i.ArmourYellow;
        case ItemEnum.ArmourRed: return GameAssets.i.ArmourRed;
        case ItemEnum.BootsBrown: return GameAssets.i.BootsBrown;
        case ItemEnum.BootsSilver: return GameAssets.i.BootsSilver;
        case ItemEnum.BootsBlue: return GameAssets.i.BootsBlue;
        case ItemEnum.BootsYellow: return GameAssets.i.BootsYellow;
        case ItemEnum.BootsRed: return GameAssets.i.BootsRed;
        case ItemEnum.GlovesBrown: return GameAssets.i.GlovesBrown;
        case ItemEnum.GlovesSilver: return GameAssets.i.GlovesSilver;
        case ItemEnum.GlovesBlue: return GameAssets.i.GlovesBlue;
        case ItemEnum.GlovesYellow: return GameAssets.i.GlovesYellow;
        case ItemEnum.GlovesRed: return GameAssets.i.GlovesRed;
        case ItemEnum.HatBrown: return GameAssets.i.HatBrown;
        case ItemEnum.HatSilver: return GameAssets.i.HatSilver;
        case ItemEnum.HatBlue: return GameAssets.i.HatBlue;
        case ItemEnum.HatYellow: return GameAssets.i.HatYellow;
        case ItemEnum.HatRed: return GameAssets.i.HatRed;
        case ItemEnum.HelmetBrown: return GameAssets.i.HelmetBrown;
        case ItemEnum.HelmetSilver: return GameAssets.i.HelmetSilver;
        case ItemEnum.HelmetBlue: return GameAssets.i.HelmetBlue;
        case ItemEnum.HelmetYellow: return GameAssets.i.HelmetYellow;
        case ItemEnum.HelmetRed: return GameAssets.i.HelmetRed;
        case ItemEnum.SwordBrown: return GameAssets.i.SwordBrown;
        case ItemEnum.SwordSilverAndYellow: return GameAssets.i.SwordSilverAndYellow;
        case ItemEnum.SwordSilverAndBlack: return GameAssets.i.SwordSilverAndBlack;
        case ItemEnum.SwordYellow: return GameAssets.i.SwordYellow;
        case ItemEnum.SwordRed: return GameAssets.i.SwordRed;
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
    public static string GetName(ItemEnum itemType)
    {
        switch (itemType)
        {
            default: return "Bruh";
            case ItemEnum.Orange: return "Orange";
            case ItemEnum.Grape: return "Grape";
            case ItemEnum.Pineapple: return "Pineapple";
            case ItemEnum.Peach: return "Peach";
            case ItemEnum.Pitahaya: return "Pitahaya";
            case ItemEnum.Pepper: return "Pepper";
            case ItemEnum.FlaskGreen: return "Green Flask";
            case ItemEnum.FlaskRed: return "Red Flask";
            case ItemEnum.FlaskPurple: return "Purple Flask";
            case ItemEnum.FlaskOrange: return "Orange Flask";
            case ItemEnum.ArmourBrown: return "Brown Armour";
            case ItemEnum.ArmourSilver: return "Silver Armour";
            case ItemEnum.ArmourBlue: return "Blue Armour";
            case ItemEnum.ArmourYellow: return "Yellow Armour";
            case ItemEnum.ArmourRed: return "Red Armour";
            case ItemEnum.BootsBrown: return "Brown Boots";
            case ItemEnum.BootsSilver: return "Silver Boots";
            case ItemEnum.BootsBlue: return "Blue Boots";
            case ItemEnum.BootsYellow: return "Yellow Boots";
            case ItemEnum.BootsRed: return "Red Boots";
            case ItemEnum.GlovesBrown: return "Brown Gloves";
            case ItemEnum.GlovesSilver: return "Silver Gloves";
            case ItemEnum.GlovesBlue: return "Blue Gloves";
            case ItemEnum.GlovesYellow: return "Yellow Gloves";
            case ItemEnum.GlovesRed: return "Red Gloves";
            case ItemEnum.HatBrown: return "Brown Hat";
            case ItemEnum.HatSilver: return "Silver Hat";
            case ItemEnum.HatBlue: return "Blue Hat";
            case ItemEnum.HatYellow: return "Yellow Hat";
            case ItemEnum.HatRed: return "Red Hat";
            case ItemEnum.HelmetBrown: return "Brown Helmet";
            case ItemEnum.HelmetSilver: return "Silver Helmet";
            case ItemEnum.HelmetBlue: return "Blue Helmet";
            case ItemEnum.HelmetYellow: return "Yellow Helmet";
            case ItemEnum.HelmetRed: return "Red Helmet";
            case ItemEnum.SwordBrown: return "Brown Sword";
            case ItemEnum.SwordSilverAndYellow: return "Silver and Yellow Sword";
            case ItemEnum.SwordSilverAndBlack: return "Silver and Black Sword";
            case ItemEnum.SwordYellow: return "Yellow Sword";
            case ItemEnum.SwordRed: return "Red Sword";
        }
    }
}
