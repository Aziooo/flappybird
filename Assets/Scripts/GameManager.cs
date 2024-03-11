using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player2 player2;

    public Player1 player1;
    
    public TextMeshProUGUI scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    public GameObject players;

    public Enemy enemy;


    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        
    }

    public void Play()
    {
        score = 0;

        scoreText.text = score.ToString();

        gameOver.SetActive(false);

        playButton.SetActive(false);
        
        Time.timeScale = 1f;

        player1.enabled = true;

        player2.enabled = true;

        enemy.enabled = true;

        //clear all pipes before game start
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }


    }

    public void Pause()
    {
        Time.timeScale = 0f;

        player1.enabled = false;

        player2.enabled = false;

        enemy.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);

        playButton.SetActive(true);

        Pause();
    }


}
