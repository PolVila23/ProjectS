using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    [SerializeField] private GameObject openButton;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private  LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        
        uiInventory.SetInventory(inventory);
    }

    public void CloseInventory() {
        openButton.SetActive(true);
        closeButton.SetActive(false);
        uiInventory.gameObject.SetActive(false);
    }

    public void OpenInventory() {

        if (!levelController.play) {
            openButton.SetActive(false);
            closeButton.SetActive(true);
            uiInventory.gameObject.SetActive(true);
        }
    }
}
