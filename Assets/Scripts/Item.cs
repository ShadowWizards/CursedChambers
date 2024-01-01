using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public enum ItemType {
       fruit1,
       fruit2,
       fruit3,
       fruit4,
       fruit5,
       fruit6
    }

    public static int GetCost(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.fruit1:       return 10;
        case ItemType.fruit2:       return 10;
        case ItemType.fruit3:       return 20;
        case ItemType.fruit4:       return 30;
        case ItemType.fruit5:       return 40;
        case ItemType.fruit6:       return 50;
        }
    }

    public static Sprite GetSprite(ItemType itemType) {
        switch (itemType) {
        default:
        case ItemType.fruit1:       return GameAssets.i.fruit1;
        case ItemType.fruit2:       return GameAssets.i.fruit2;
        case ItemType.fruit3:       return GameAssets.i.fruit3;
        case ItemType.fruit4:       return GameAssets.i.fruit4;
        case ItemType.fruit5:       return GameAssets.i.fruit5;
        case ItemType.fruit6:       return GameAssets.i.fruit6;
        }
    }

}
