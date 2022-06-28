using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    //const float G = 6.67408f;

    public Rigidbody2D rb;

    //public static List<Attractor> Attractors;
    //public static Spaceship[] Spaceships;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        //Spaceships = FindObjectsOfType<Spaceship>();

    }

    /*void OnEnable()
    {
        if (Attractors == null) Attractors = new List<Attractor> ();
        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    void FixedUpdate ()
    {
        foreach(Attractor attractor in Attractors)
        {
            if (attractor != this) Attract(attractor);
        }
    }*/

    /*void FixedUpdate()
    {
        foreach (Spaceship spaceship in Spaceships)
        {
            Attract(spaceship);
        }
    }

        void Attract (Spaceship a)
    {
        Rigidbody2D rbToAttract = a.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f) return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 1.3f);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }*/
}
