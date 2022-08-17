using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreatorController : MonoBehaviour
{
    private GameObject selected;
 
    public void ChangeSize(float n) {
        Debug.Log("valueChanged" + n);
    }

    public void Select (ref GameObject gameObject) {
        selected = gameObject;

        //this.minValue = 0.5f;

        switch (selected.name) {
            default: break;

            case "planet": 
                break;
        }        
    }
}
