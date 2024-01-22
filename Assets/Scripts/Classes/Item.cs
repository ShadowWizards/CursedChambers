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
                case ItemEnum.FlaskGreen: 
                case ItemEnum.FlaskOrange:
                case ItemEnum.FlaskRed:
                case ItemEnum.FlaskPurple:
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

    public bool GiveMaxHp
    {
        get
        {
            switch (ItemType)
            {
                case ItemEnum.ArmourBlue:
                case ItemEnum.ArmourBrown:
                case ItemEnum.ArmourRed:
                case ItemEnum.ArmourSilver:
                case ItemEnum.ArmourYellow:
                    
                case ItemEnum.GlovesBlue:
                case ItemEnum.GlovesBrown:
                case ItemEnum.GlovesRed:
                case ItemEnum.GlovesSilver:
                case ItemEnum.GlovesYellow:
                    
                case ItemEnum.HelmetBlue:
                case ItemEnum.HelmetBrown:
                case ItemEnum.HelmetRed:
                case ItemEnum.HelmetSilver:
                case ItemEnum.HelmetYellow:
                    return true;
                default:
                    return false;
            }
        }
    }

    public bool GiveStr
    {
        get
        {
            switch (ItemType)
            {
                case ItemEnum.SwordBrown:
                case ItemEnum.SwordRed:
                case ItemEnum.SwordYellow:
                case ItemEnum.SwordSilverAndBlack:
                case ItemEnum.SwordSilverAndYellow:
                    return true;
                default:
                    return false;
            }
        }
    }
    
    public bool isEquipped;
    
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
       Error,
    }

    public static int GetCost(ItemEnum itemType) {
        switch (itemType) {
        default:                    return 0;
        case ItemEnum.Orange:       return 10;
        case ItemEnum.Grape:       return 10;
        case ItemEnum.Pineapple:       return 20;
        case ItemEnum.Peach:       return 30;
        case ItemEnum.Pitahaya:       return 40;
        case ItemEnum.Pepper:       return 50;

        case ItemEnum.FlaskGreen:     return 10;
        case ItemEnum.FlaskRed:     return 20;
        case ItemEnum.FlaskPurple:     return 30;
        case ItemEnum.FlaskOrange:     return 40;

        case ItemEnum.ArmourBrown: return 10;
        case ItemEnum.ArmourSilver: return 25;
        case ItemEnum.ArmourBlue: return 50;
        case ItemEnum.ArmourYellow: return 100;
        case ItemEnum.ArmourRed: return 150;

        case ItemEnum.BootsBrown: return 10;
        case ItemEnum.BootsSilver: return 25;
        case ItemEnum.BootsBlue: return 50;
        case ItemEnum.BootsYellow: return 100;
        case ItemEnum.BootsRed: return 150;

        case ItemEnum.GlovesBrown: return 10;
        case ItemEnum.GlovesSilver: return 25;
        case ItemEnum.GlovesBlue: return 50;
        case ItemEnum.GlovesYellow: return 100;
        case ItemEnum.GlovesRed: return 150;

        case ItemEnum.HatBrown: return 10;
        case ItemEnum.HatSilver: return 25;
        case ItemEnum.HatBlue: return 50;
        case ItemEnum.HatYellow: return 100;
        case ItemEnum.HatRed: return 150;

        case ItemEnum.HelmetBrown: return 10;
        case ItemEnum.HelmetSilver: return 25;
        case ItemEnum.HelmetBlue: return 50;
        case ItemEnum.HelmetYellow: return 100;
        case ItemEnum.HelmetRed: return 150;

        case ItemEnum.SwordBrown: return 10;
        case ItemEnum.SwordSilverAndYellow: return 25;
        case ItemEnum.SwordSilverAndBlack: return 50;
        case ItemEnum.SwordYellow: return 100;
        case ItemEnum.SwordRed: return 150;
        }
    }

    public static Sprite GetSprite(ItemEnum itemType) {
        switch (itemType) {
        default: return GameAssets.i.Error;
        case ItemEnum.Orange:       return GameAssets.i.Orange;
        case ItemEnum.Grape:        return GameAssets.i.Grape;
        case ItemEnum.Pineapple:       return GameAssets.i.Pineapple;
        case ItemEnum.Peach:       return GameAssets.i.Peach;
        case ItemEnum.Pitahaya:       return GameAssets.i.Pitahaya;
        case ItemEnum.Pepper:       return GameAssets.i.Pepper;
        case ItemEnum.FlaskGreen:     return GameAssets.i.FlaskGreen;
        case ItemEnum.FlaskRed:     return GameAssets.i.FlaskRed;
        case ItemEnum.FlaskPurple:     return GameAssets.i.FlaskPurple;
        case ItemEnum.FlaskOrange:     return GameAssets.i.FlaskOrange;
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

    public static float GetMaxHP(ItemEnum itemType)
    {
        switch (itemType)
        {
            default:
            case ItemEnum.ArmourBrown: return 1;
            case ItemEnum.ArmourSilver: return 2;
            case ItemEnum.ArmourBlue: return 4;
            case ItemEnum.ArmourYellow: return 5;
            case ItemEnum.ArmourRed: return 6;
                    
            case ItemEnum.GlovesBrown: return 1;
            case ItemEnum.GlovesSilver: return 2;
            case ItemEnum.GlovesBlue: return 4;
            case ItemEnum.GlovesYellow: return 5;
            case ItemEnum.GlovesRed: return 6;

            case ItemEnum.HelmetBrown: return 1;  
            case ItemEnum.HelmetSilver: return 2;   
            case ItemEnum.HelmetBlue: return 4;
            case ItemEnum.HelmetYellow: return 5;
            case ItemEnum.HelmetRed: return 6;
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
    public static int GetChance(ItemEnum itemType)
    {
        switch (itemType)
        {
            default:                            return 0;
            case ItemEnum.Orange:               return 100;
            case ItemEnum.Grape:                return 70;
            case ItemEnum.Pineapple:            return 50;
            case ItemEnum.Peach:                return 30;
            case ItemEnum.Pitahaya:             return 20;
            case ItemEnum.Pepper:               return 20;

            case ItemEnum.FlaskGreen:           return 10;
            case ItemEnum.FlaskRed:             return 10;
            case ItemEnum.FlaskPurple:          return 10;
            case ItemEnum.FlaskOrange:          return 10;

            case ItemEnum.ArmourBrown:          return 100;
            case ItemEnum.ArmourSilver:         return 70;
            case ItemEnum.ArmourBlue:           return 50;
            case ItemEnum.ArmourYellow:         return 30;
            case ItemEnum.ArmourRed:            return 10;

            case ItemEnum.BootsBrown:           return 100;
            case ItemEnum.BootsSilver:          return 70;
            case ItemEnum.BootsBlue:            return 50;
            case ItemEnum.BootsYellow:          return 30;
            case ItemEnum.BootsRed:             return 10;

            case ItemEnum.GlovesBrown:          return 100;
            case ItemEnum.GlovesSilver:         return 70;
            case ItemEnum.GlovesBlue:           return 50;
            case ItemEnum.GlovesYellow:         return 30;
            case ItemEnum.GlovesRed:            return 10;

            case ItemEnum.HatBrown:             return 100;
            case ItemEnum.HatSilver:            return 70;
            case ItemEnum.HatBlue:              return 50;
            case ItemEnum.HatYellow:            return 30;
            case ItemEnum.HatRed:               return 10;

            case ItemEnum.HelmetBrown:          return 100;
            case ItemEnum.HelmetSilver:         return 70;
            case ItemEnum.HelmetBlue:           return 50;
            case ItemEnum.HelmetYellow:         return 30;
            case ItemEnum.HelmetRed:            return 10;

            case ItemEnum.SwordBrown:           return 100;
            case ItemEnum.SwordSilverAndYellow: return 70;
            case ItemEnum.SwordSilverAndBlack:  return 50;
            case ItemEnum.SwordYellow:          return 30;
            case ItemEnum.SwordRed:             return 10;
        }
    }

    public static float GetStr(ItemEnum itemType)
    {
        switch (itemType)
        {
            default:
            case ItemEnum.SwordBrown: return 1;
            case ItemEnum.SwordSilverAndYellow: return 2;
            case ItemEnum.SwordSilverAndBlack: return 3;
            case ItemEnum.SwordYellow: return 4;
            case ItemEnum.SwordRed: return 5;
        }
    }
    public static float GetSpeed(ItemEnum itemType)
    {
        switch (itemType)
        {
            default:
            case ItemEnum.BootsBrown: return 1;
            case ItemEnum.BootsSilver: return 2;
            case ItemEnum.BootsBlue: return 3;
            case ItemEnum.BootsYellow: return 4;
            case ItemEnum.BootsRed: return 5;
                    
            case ItemEnum.HatBrown: return 1;
            case ItemEnum.HatSilver: return 2;
            case ItemEnum.HatBlue: return 3;
            case ItemEnum.HatYellow: return 4;
            case ItemEnum.HatRed: return 5;
        }
    }
}