using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioSource gameOverMusicSource;
    public AudioSource buttonClickSource;
    public AudioSource pointSource;

    public AudioClip backgroundMusicClip;
    public AudioClip gameOverMusicClip;
    public AudioClip buttonClickClip;
    public AudioClip pointClip;

    void Start()
    {
        // Set up background music
        backgroundMusicSource.clip = backgroundMusicClip;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();

        // Ensure the game over music and button click are not set to loop
        gameOverMusicSource.loop = false;
        buttonClickSource.loop = false;

        gameOverMusicSource.clip = gameOverMusicClip;
        buttonClickSource.clip = buttonClickClip;
        pointSource.clip = pointClip;

    }

    public void PlayBackgroundMusic()
    {
        backgroundMusicSource.Play();
        gameOverMusicSource.Stop();
    }

    public void PlayGameOverMusic()
    {
        // Stops the background music and plays the game over music
        backgroundMusicSource.Stop();
        
        gameOverMusicSource.Play();
    }

    public void PlayButtonClick()
    {
        buttonClickSource.PlayOneShot(buttonClickClip);  // Use PlayOneShot for sound effects
    }

    public void PlayPointAudio()
    {
        pointSource.Play();
    }
}
