using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    // Reference for the audio we used
    public AudioSource levelMusic;
    public AudioSource deathSong;
    public AudioSource LichSound;
    public AudioSource victoryMusic;
    // bool
    public bool levelSong = true;
    public bool DeathSong = false;
    public bool lich_Sound = true;
    public bool victorySong = false;

    void Start()
    {

    }

    void Update()
    {

    }

    // This plays the music set for the level
    public void LevelMusic()
    {
        levelSong = true;
        DeathSong = false;
        lich_Sound = true;
        victorySong = false;
        levelMusic.Play();
        LichSound.Play();

    }

    // This stops the music in the level and plays a death sound
    public void DeathSound()
    {
        if (levelMusic.isPlaying)
        {
            levelSong = false;
            lich_Sound = false;
            levelMusic.Stop();
            LichSound.Stop();

        }
        if (!deathSong.isPlaying && DeathSong == false && victorySong == false)
        {
            deathSong.Play();
            DeathSong = true;
        }
    }

    // Stops the music in the level and plays the Victory sound
    public void VictorySound()
    {
        if (levelMusic.isPlaying)
        {
            levelSong = false;
            lich_Sound = false;
            levelMusic.Stop();
            LichSound.Stop();

        }
        if (!deathSong.isPlaying && DeathSong == false && victorySong == false)
        {
            victoryMusic.Play();
            victorySong = true;
        }
    }
}
