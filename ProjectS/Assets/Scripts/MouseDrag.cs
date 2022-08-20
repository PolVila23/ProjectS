using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MouseDrag : MonoBehaviour
{
    private bool isDraggable;
    private float startX;
    private float startY;
    public bool isBeingHeld = false;

    public static short order = -32768;

    [SerializeField] private static LevelController levelController;
    [SerializeField] private static LevelCreatorController levelCreatorController;

    private bool levelCreator;
    public static GameObject lastSelected;
    

    void Start() {
        if (levelController == null) levelController = FindObjectOfType<LevelController>();

        
        levelCreator = false;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "LevelCreator") {
            levelCreator = true;
            if (levelCreatorController == null) levelCreatorController = FindObjectOfType<LevelCreatorController>();
        }
        
        isDraggable = false;

        switch (this.tag) {
            default: break;
            case "Planet": isDraggable = true; break;
            case "Sun": if (levelCreator) isDraggable = true; break;
            case "Asteroid": if (levelCreator) isDraggable = true; break;
            case "End": if (levelCreator) isDraggable = true; break;
        }
    }
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

        if (levelCreator) {
            lastSelected = this.gameObject;

            levelCreatorController.Select(ref lastSelected);
        }
    }

    private void OnMouseDown()
    {
        if (!levelController.play && Input.GetMouseButtonDown(0) && isDraggable)
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
