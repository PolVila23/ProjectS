using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public bool isDraggable;
    private float startX;
    private float startY;
    public bool isBeingHeld = false;
    
    public static GameObject lastSelected;

    public static short order = -32768;

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector3(mousePos.x - startX, mousePos.y - startY, 0);
        }
    }

    public void Select() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = order;
        ++order;

        lastSelected = this.gameObject;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && isDraggable)
        {
            Select();

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startX = mousePos.x - this.transform.position.x;
            startY = mousePos.y - this.transform.position.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
