using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    // reference to the game over UI
    public GameObject gameOverUI;

    void Start()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Activates the game over UI when game is over
    public void GameIsOver()
    {
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
        gameOverUI.SetActive(true);
    }

    // Reloads to the first game scene, restarting the game
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
        FindObjectOfType<SoundEffects>().LevelMusic();
        
    }

    // Loads the player back to the MainMenu scene
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

