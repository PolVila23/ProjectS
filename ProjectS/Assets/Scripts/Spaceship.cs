using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{

    private const float G = 6.67408f;

    public float initialSpeed;

    public Rigidbody2D rb;

    public static Attractor[] Attractors;

    private Finish finish;

    private Vector2 posAnt;

    private bool play;

    private GameObject StartButton;
    private GameObject StopButton;


    // Start is called before the first frame update
    void Start()
    {
        play = false;
        rb = GetComponent<Rigidbody2D>();
        
        StartButton = GameObject.Find("StartButton");
        StopButton = GameObject.Find("StopButton");
        StopButton.SetActive(false);
    }

    void FixedUpdate()
    {
        if (play) {
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
        if (play) {
            if (finish is null || other.name != finish.name) {
                Debug.Log("Haha t'has xocat lol");
                StopLevel();
            }
            else {
                SceneManager.LoadScene("YouWin");
            }
        }
    }

    public void StartLevel() {

        if (!play) {
            play = true;

            Vector2 force = new Vector2(0, initialSpeed);
            
            rb.AddForce(force);

            posAnt = transform.position;
            Attractors = FindObjectsOfType<Attractor>();
            finish = FindObjectOfType<Finish>();
        }
    }

    public void StopLevel() {
        play = false;
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, -20);
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        StartButton.SetActive(true);
        StopButton.SetActive(false);
    }

    public void ResetScene() {
        Attractors = FindObjectsOfType<Attractor>();
        finish = FindObjectOfType<Finish>();

        foreach (Attractor attractor in Attractors) {
            Destroy(attractor);
        }

    }
}
