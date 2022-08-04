using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public enum ItemType {
        Planet,
        Asteroid,
        Sun,
        Finish,
    }

    public ItemType itemType;

    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.Planet: return ItemAssets.Instance.planetSprite;
            case ItemType.Asteroid: return ItemAssets.Instance.asteroidSprite;
            case ItemType.Sun: return ItemAssets.Instance.sunSprite;
            case ItemType.Finish: return ItemAssets.Instance.finishSprite;
        }
    }
}
