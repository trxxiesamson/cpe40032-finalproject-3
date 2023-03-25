using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    // reference to the Victory UI
    public GameObject victoryUI;

    void Start()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Activates the game over UI when the Lich has been defeated
    public void Victory()
    {
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
        victoryUI.SetActive(true);
    }

    // Loads the player back to the MainMenu scene
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // Quits the application
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
