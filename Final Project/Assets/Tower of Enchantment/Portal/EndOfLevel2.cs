using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player") // If player collides with portal, game scene will move to level 3
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
