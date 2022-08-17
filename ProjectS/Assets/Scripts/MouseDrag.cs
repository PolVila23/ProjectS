using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MouseDrag : MonoBehaviour
{
    public bool isDraggable;
    private float startX;
    private float startY;
    public bool isBeingHeld = false;

    public static short order = -32768;

    [SerializeField] private static LevelController levelController;

    private bool levelCreator;
    public static GameObject lastSelected;
    private Slider slider = null;

    void Start() {
        if (levelController == null) levelController = FindObjectOfType<LevelController>();

        levelCreator = false;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "LevelCreator") {
            levelCreator = true;
            slider = FindObjectOfType<Slider>();
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

            slider.minValue = 0.5f;
            //slider.Select(ref lastSelected);
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
