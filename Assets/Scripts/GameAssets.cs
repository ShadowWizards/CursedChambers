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

    public Sprite fruit1;
    public Sprite fruit2;
    public Sprite fruit3;
    public Sprite fruit4;
    public Sprite fruit5;
    public Sprite fruit6;
}
