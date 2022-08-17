using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public bool play;
    private GameObject StartButton;
    private GameObject StopButton;

    private Spaceship spaceship; 

    void Start()
    {
        play = false;
        
        StartButton = GameObject.Find("StartButton");
        StopButton = GameObject.Find("StopButton");
        StopButton.SetActive(false);
    }


    public void StartLevel() {

        if (!play) {
            spaceship = FindObjectOfType<Spaceship>();

            play = true;
            spaceship.StartLevel();

            StartButton.SetActive(false);
            StopButton.SetActive(true);
        }
    }

    public void StopLevel() {
        play = false;
        spaceship.StopLevel();

        StartButton.SetActive(true);
        StopButton.SetActive(false);
    }

    public void Win() {
        Debug.Log("You Win");
        SceneManager.LoadScene("YouWin");
    }

    public void Lose() {
        Debug.Log("Haha t'has xocat lol");
        StopLevel();
    }

    public void ResetScene() {
        Attractor[] Attractors = FindObjectsOfType<Attractor>();
        Finish finish = FindObjectOfType<Finish>();

        foreach (Attractor attractor in Attractors) {
            Destroy(attractor);
        }
        
        Destroy(finish);
    }
}
