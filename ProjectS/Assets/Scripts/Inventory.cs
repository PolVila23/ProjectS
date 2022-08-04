using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item> ();

        AddItem(new Item { itemType = Item.ItemType.Planet});
        AddItem(new Item { itemType = Item.ItemType.Sun});
        AddItem(new Item { itemType = Item.ItemType.Asteroid});
        AddItem(new Item { itemType = Item.ItemType.Finish});
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public List<Item> GetItemList() {
        return itemList;
    }
}
