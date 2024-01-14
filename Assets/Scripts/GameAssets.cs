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
}
