using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpriteAssets : MonoBehaviour
{
    private static GameSpriteAssets _instance;

    public static GameSpriteAssets instance{
        get{
            if(_instance == null) _instance = (Instantiate(Resources.Load("GameSpriteAssets")) as GameObject).GetComponent<GameSpriteAssets>();
            return _instance;
        }
    }

    public Sprite sword_Sway;
    public Sprite sword_Champ;
    public Sprite shield_Crude;
    public Sprite shield_Nail;
    public Sprite shield_Champ;
}
