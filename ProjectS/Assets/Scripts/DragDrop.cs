using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour
{   
    private GameObject LastSelected;
    [HideInInspector] public GameObject Selected;

    private float startX;
    private float startY;

    [SerializeField] private GameObject Trash;

    public float order = 0;

    private LevelController levelController;
    private LevelCreatorController levelCreatorController;

    void Start() {
        levelController = FindObjectOfType<LevelController>();

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "LevelCreator") levelCreatorController = FindObjectOfType<LevelCreatorController>();
    }

    private void Update() {
        if (!levelController.play && Input.GetMouseButtonDown(0)) {
            Debug.Log("Check hit");
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
        
        if (LastSelected != null) LastSelected.transform.Find("Selection").gameObject.SetActive(false);

        if (hit2D.collider != null) {
            if (!hit2D.collider.gameObject.HasTag("Drag")) return;

            Selected = hit2D.transform.gameObject;

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startX = mousePos.x - Selected.transform.position.x;
            startY = mousePos.y - Selected.transform.position.y;
            
            order -= 0.0001f;

            if (levelCreatorController != null) {
                levelCreatorController.Select(ref Selected);
                Selected.transform.Find("Selection").gameObject.SetActive(true);
            }
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

        if (Selected != null) {
            LastSelected = Selected;
            
            if (((Vector2)(Selected.transform.position) + new Vector2(startX, startY) - (Vector2)(Trash.transform.position)).magnitude <= 5) { //Centrat al ratoli (+ new Vector2(startX, startY)) o centrat al centre de l'objecte?
                Destroy(Selected);
                LastSelected = null;
            }

            Selected = null;
        }
    }
}

