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
    public GameObject resetButton;
    public GameObject resumeButton;
    public GameObject gameOver;
    public GameObject getReady;
    public AudioManager audioManager;
    public Text scoreText;
    public Text highestScoreText;

    private bool isPaused = false;
    private bool isGameOver = true;

    private void Awake()
    {
        Time.timeScale = 0;

        playButton.SetActive(true);
        resumeButton.SetActive(false); 
        resetButton.SetActive(true);
        gameOver.SetActive(false);

        highestScore = PlayerPrefs.GetFloat("highestScore", 0f);
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        highestScoreText.text = highestScore.ToString();

        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exit button pressed! Quit the game!");
            SaveRecord();
            Application.Quit();

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        ?
        }*/

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            audioManager.PlayButtonClick();

            Debug.Log("Press Esc!");

            if (!isGameOver)
            {
                if (isPaused)
                {
                    
                    Resume();
                }
                else
                {
                    
                    Pause();
                
                }
            }
                
        }

        if (!isGameOver)
        {
            SetHighestScore();
        }
    }

    public void IncreasingScore()
    {
        score++;
        audioManager.PlayPointAudio();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");

        player.enabled = false;
        isGameOver = true;
        Time.timeScale = 0;

        playButton.SetActive(true);
        resetButton.SetActive(true);
        gameOver.SetActive(true);
        audioManager.PlayGameOverMusic();

    }

    public void Play()
    {
        playButton.SetActive(false);
        getReady.SetActive(false);
        resetButton.SetActive(false);
        gameOver.SetActive(false);

        audioManager.PlayButtonClick();
        audioManager.PlayBackgroundMusic();

        score = 0f;
        Time.timeScale = 1f;
        player.enabled = true;
        isGameOver = false;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;


        resumeButton.SetActive(true);
        Debug.Log("Pause!");
    }


    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;

        audioManager.PlayButtonClick();

        resumeButton.SetActive(false);
        Debug.Log("Resume!");
    }

    public void Reset()
    {
        audioManager.PlayButtonClick();

        highestScore = 0f;
        SaveRecord();
        highestScoreText.text = PlayerPrefs.GetFloat("highestScore", 0).ToString();
        Debug.Log("Reset!");
    }

    void SetHighestScore()
    {
        if (highestScore < score)
        {
            highestScore = score;
            SaveRecord();
        }
    }

    void SaveRecord()
    {
        PlayerPrefs.SetFloat("highestScore", highestScore);
        PlayerPrefs.Save();
    }
}
