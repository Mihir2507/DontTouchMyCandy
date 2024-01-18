using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Items {
    public enum ItemType{
        sword_Sway,
        sword_Champ,
        shield_Crude,
        shield_Nail,
        shield_Champ
    }

    public static int GetCost(ItemType itemType)
    {
        switch(itemType){
            default:
            case ItemType.sword_Sway: return 100;
            case ItemType.sword_Champ: return 500;
            case ItemType.shield_Crude: return 100;
            case ItemType.shield_Nail: return 250;
            case ItemType.shield_Champ: return 500;
        }
    }

    public static Sprite GetSprite(ItemType itemType){
        switch(itemType){
            default:
            case ItemType.sword_Sway: return GameSpriteAssets.instance.sword_Sway;
            case ItemType.sword_Champ: return GameSpriteAssets.instance.sword_Champ;
            case ItemType.shield_Crude: return GameSpriteAssets.instance.shield_Crude;
            case ItemType.shield_Nail: return GameSpriteAssets.instance.shield_Nail;
            case ItemType.shield_Champ: return GameSpriteAssets.instance.shield_Champ;
        }
    }

    public static GameObject GetGameObjects(ItemType itemType){
        switch(itemType){
            default:
            case ItemType.sword_Sway: return GameObjectAssets.instance.swaySword;
            case ItemType.sword_Champ: return GameObjectAssets.instance.champSword;
            case ItemType.shield_Crude: return GameObjectAssets.instance.crudeShield;
            case ItemType.shield_Nail: return GameObjectAssets.instance.nailShield;
            case ItemType.shield_Champ: return GameObjectAssets.instance.champShield;
        }
    }   
}
