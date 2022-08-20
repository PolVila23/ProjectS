using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreatorController : MonoBehaviour
{
    private GameObject selected;
    private Slider slider = null;
    

    public void Start() {
        slider = FindObjectOfType<Slider>();
    }


    public void ChangeSize(float n) {
        Debug.Log(n);
        if (selected != null) {
            if (selected.tag == "End") selected.transform.localScale = new Vector3(n, n/2, n); 
            else selected.transform.localScale = new Vector3(n, n, n);
        }
    }


    public void Select (ref GameObject gameObject) {
        selected = gameObject;

        switch (selected.tag) {
            default: break;

            case "Planet": 
                slider.minValue = 0.5f;
                slider.maxValue = 4;
                break;
            
            case "Sun": 
                slider.minValue = 1.5f;
                slider.maxValue = 7;
                break;
            
            case "Asteroid": 
                slider.minValue = 0.25f;
                slider.maxValue = 4;
                break;

            case "End": 
                slider.minValue = 10f;
                slider.maxValue = 40;
                break;
        }

        slider.value = selected.transform.localScale.x;
    }
}
