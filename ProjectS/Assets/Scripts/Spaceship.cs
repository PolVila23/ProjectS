using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //speed = speed / 100;
        rb = GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(0, speed);
        rb.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
