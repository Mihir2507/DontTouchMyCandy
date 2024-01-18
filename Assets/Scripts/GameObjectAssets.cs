using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectAssets : MonoBehaviour
{
    private static GameObjectAssets _instance;

    public static GameObjectAssets instance{
        get{
            if(_instance == null) _instance = (Instantiate(Resources.Load("GameObjectAssets")) as GameObject).GetComponent<GameObjectAssets>();
            return _instance;
        }
    }
    public GameObject swaySword;
    public GameObject champSword;
    public GameObject crudeShield;
    public GameObject nailShield;
    public GameObject champShield;

}
