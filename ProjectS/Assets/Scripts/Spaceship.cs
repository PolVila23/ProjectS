using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spaceship : MonoBehaviour
{

    private const float G = 6.67408f;

    public float initialSpeed;

    public Rigidbody2D rb;

    public static Attractor[] Attractors;
    private static Finish finish;

    private Vector2 posAnt;

    [SerializeField] private LevelController levelController;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (levelController.play) {
            Vector2 totalForce = new Vector2(0, 0);
            foreach (Attractor attractor in Attractors)
            {
                Vector2 force = new Vector2(0, 0);
                Attract(attractor, ref force);
                totalForce += force;
            }

            rb.AddForce(totalForce);

            Vector2 posNou = transform.position;
            Vector2 direction = posNou - posAnt;

            if (direction.magnitude != 0)
            {
                float lookAngle = Mathf.Atan2(direction.y, direction.x)  * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(lookAngle - 90, Vector3.forward);
            }

            posAnt = transform.position;
        }
    }

    void Attract(Attractor a, ref Vector2 force)
    {
        Rigidbody2D rbAttractor = a.rb;

        Vector2 direction = rbAttractor.position - rb.position;
        float distance = direction.magnitude;

        if (distance == 0f) return;

        float forceMagnitude = G * (rbAttractor.mass * rb.mass) / Mathf.Pow(distance, 1.5f);
        force = direction.normalized * forceMagnitude;

        //rb.AddForce(force);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelController.play) {
            if (finish is null || other.name != finish.name) {
                levelController.Lose();
            }
            else {
                levelController.Win();
            }
        }
    }

    public void StartLevel() {

        Attractors = FindObjectsOfType<Attractor>();
        finish = FindObjectOfType<Finish>();

        Vector2 force = new Vector2(0, initialSpeed);    
        rb.AddForce(force);
        posAnt = transform.position;
    }

    public void StopLevel() {

        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, -20);
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }
}
