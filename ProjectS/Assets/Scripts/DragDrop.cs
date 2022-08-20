using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private GameObject Selected;

    private float startX;
    private float startY;

    private float order = 0;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CheckHitObject();
        }
        if (Input.GetMouseButton(0)) {
            DragObject();
        }
        if (Input.GetMouseButtonUp(0)) {
            DropObject();
        }
    }

    private void CheckHitObject() {
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (hit2D.collider != null) {
            //if (!hit2D.collider.CompareTag("planet")) return;

            Selected = hit2D.transform.gameObject;

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startX = mousePos.x - Selected.transform.position.x;
            startY = mousePos.y - Selected.transform.position.y;
            
            order -= 0.0001f;
        }
    }

    private void DragObject() {
        if (Selected != null) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Selected.transform.position = new Vector3(mousePos.x - startX, mousePos.y - startY, order);
        }
    }

    private void DropObject() {
        Selected = null;
    }
}

