using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player") // If player collides with the portal, game scene will move on to level 2
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
