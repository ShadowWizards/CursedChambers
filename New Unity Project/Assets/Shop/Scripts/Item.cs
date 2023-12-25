/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public enum ItemType {
        ArmorNone,
        Armor_1,
        Armor_2,
        HelmetNone,
        Helmet,
        HealthPotion,
        Sword_1,
        Sword_2
    }

    public static int GetCost(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.ArmorNone:        return 0;
        case ItemType.Armor_1:          return 30;
        case ItemType.Armor_2:          return 100;
        case ItemType.HelmetNone:       return 0;
        case ItemType.Helmet:           return 90;
        case ItemType.HealthPotion:     return 30;
        case ItemType.Sword_1:          return 0;
        case ItemType.Sword_2:          return 150;
        }
    }

    public static Sprite GetSprite(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.ArmorNone:    return GameAssets.i.s_ArmorNone;
        case ItemType.Armor_1:      return GameAssets.i.s_Armor_1;
        case ItemType.Armor_2:      return GameAssets.i.s_Armor_2;
        case ItemType.HelmetNone:   return GameAssets.i.s_HelmetNone;
        case ItemType.Helmet:       return GameAssets.i.s_Helmet;
        case ItemType.HealthPotion: return GameAssets.i.s_HealthPotion;
        case ItemType.Sword_1:      return GameAssets.i.s_Sword_1;
        case ItemType.Sword_2:      return GameAssets.i.s_Sword_2;
        }
    }

}
