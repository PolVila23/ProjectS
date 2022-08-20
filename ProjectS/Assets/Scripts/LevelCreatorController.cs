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
        Debug.Log("ChangeSize " + selected.name + " " + n);
        if (selected != null) {
            if (selected.HasTag("Finish")) selected.transform.localScale = new Vector3(n, n/2, n); 
            else selected.transform.localScale = new Vector3(n, n, n);
        }
    }


    public void Select (ref GameObject gameObject) {
        Debug.Log(gameObject.name + "selected");
        selected = gameObject;

        slider.minValue = 0;
        slider.maxValue = 100;
        slider.SetValueWithoutNotify(3); //Necessari pq sino salta OnValueChanged al cambiar minim o maxim (si el valor estava per sota/sobre)

        if (selected.HasTag("Planet")) {
            slider.minValue = 0.5f;
            slider.maxValue = 4;
        }
        else if (selected.HasTag("Sun")) {
            slider.minValue = 1.5f;
            slider.maxValue = 7;
        }
        else if (selected.HasTag("Asteroid")) {
            slider.minValue = 0.25f;
            slider.maxValue = 4;
        }
        else if (selected.HasTag("Finish")) {
            slider.SetValueWithoutNotify(15); //Necessari pq sino salta OnValueChanged al cambiar minim o maxim (si el valor estava per sota/sobre)
            slider.minValue = 5;
            slider.maxValue = 30;
        }
        slider.SetValueWithoutNotify(selected.transform.localScale.x);
    }
}
