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
                case ItemEnum.Fruit1:
                case ItemEnum.Fruit2:
                case ItemEnum.Fruit3:
                case ItemEnum.Fruit4:
                case ItemEnum.Fruit5:
                case ItemEnum.Fruit6:
                    return true;
                default:
                    return false;
            }
        }
    }

    public enum ItemEnum {
       Fruit1,
       Fruit2,
       Fruit3,
       Fruit4,
       Fruit5,
       Fruit6,
       TestBuffItem
    }

    public static int GetCost(ItemEnum itemType) {
        switch (itemType) {
        default:
        case ItemEnum.Fruit1:       return 10;
        case ItemEnum.Fruit2:       return 10;
        case ItemEnum.Fruit3:       return 20;
        case ItemEnum.Fruit4:       return 30;
        case ItemEnum.Fruit5:       return 40;
        case ItemEnum.Fruit6:       return 50;
        }
    }

    public static Sprite GetSprite(ItemEnum itemType) {
        switch (itemType) {
        default:
        case ItemEnum.Fruit1:       return GameAssets.i.fruit1;
        case ItemEnum.Fruit2:       return GameAssets.i.fruit2;
        case ItemEnum.Fruit3:       return GameAssets.i.fruit3;
        case ItemEnum.Fruit4:       return GameAssets.i.fruit4;
        case ItemEnum.Fruit5:       return GameAssets.i.fruit5;
        case ItemEnum.Fruit6:       return GameAssets.i.fruit6;
        case ItemEnum.TestBuffItem:     return GameAssets.i.fruit1;
        }
    }

}
