using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Planet;
    public GameObject Asteroid;
    public GameObject Sun;
    public GameObject Finish;

    private GameObject spawned = null;


    public void Spawn() {
        Item.ItemType itemType = GetComponent<Item>().itemType;
        
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        switch (itemType) {
            default: break;
            case Item.ItemType.Planet:  spawned = Instantiate(Planet, mousePos, Quaternion.identity);
                                        break;
            case Item.ItemType.Asteroid:spawned = Instantiate(Asteroid, mousePos, Quaternion.identity);
                                        break;
            case Item.ItemType.Sun:     spawned = Instantiate(Sun, mousePos, Quaternion.identity);
                                        break;
            case Item.ItemType.Finish:  spawned = Instantiate(Finish, mousePos, Quaternion.identity);
                                        break;
            
        }
        MouseDrag md = spawned.GetComponent<MouseDrag>();
        md.isBeingHeld = true;
        md.Select();


        Debug.Log("Spawned");

        
    }

    public void OnPointerDown(PointerEventData eventData) {
        Spawn();
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("OnPointerUp");
        spawned.GetComponent<MouseDrag>().isBeingHeld = false;
    }
}
