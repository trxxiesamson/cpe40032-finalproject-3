// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpawnerSlime : MonoBehaviour
// {
//     public Transform[] spawnLocations;
//     public GameObject[] spawnPrefab;
//     public GameObject[] spawnClone;
//     public GameObject portal;   // wag pansinin
//     public GameObject extra;  // wag pansinin
//     public int waveNumber = 1; // wag pansinin

//     void Start()
//     {
//         spawnSlime();
//     }


//     void spawnSlime()
//     {
//         spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(13,0,26)) as GameObject;
//         spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[1].transform.position, Quaternion.Euler(13,0,26)) as GameObject;
//         spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[2].transform.position, Quaternion.Euler(13,0,26)) as GameObject;

//     }

//         // Triggers Portal
//     void TriggerPortal ()
//     {

//         if(portal.activeInHierarchy == false)
//         {
//             portal.SetActive(true);
//         }
//         else
//         {
//             portal.SetActive(false);
//         }
//     }
// }