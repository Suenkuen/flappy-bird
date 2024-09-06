using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score = 0f;
    public float highestScore = 0f;
    public Player player;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    public Text scoreText;
    public Text highestScoreText;

    private void Awake()
    {
        Time.timeScale = 0;
        Pause();
        playButton.SetActive(true);
        gameOver.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        highestScoreText.text = highestScore.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exit button pressed! Quit the game!");
            Application.Quit();

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }

        SetHighestScore();
    }

    public void IncreasingScore()
    {
        score++;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");

        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Play()
    {
        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);

        score = 0f;
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    void Pause()
    {
        player.enabled = false;
        Time.timeScale = 0;
    }

    void SetHighestScore()
    {
        if(highestScore < score)
        {
            highestScore = score;
        }
    }

}
