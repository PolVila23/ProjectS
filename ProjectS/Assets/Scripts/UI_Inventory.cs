using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake() {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() {
        float x = 0.7f;
        float y = -0.5f;
        float itemSlotCellSize = 170f;

        foreach(Item item in inventory.GetItemList()) {
            Transform itemSlot = Instantiate(itemSlotTemplate, itemSlotContainer);
            RectTransform itemSlotRectTransform = itemSlot.GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            itemSlot.GetComponent<Item>().itemType = item.itemType;

            ++x;
            if (x > 4) {
                x = 0;
                ++y;
            }
        }
    }
}
