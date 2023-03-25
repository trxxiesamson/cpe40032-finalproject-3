using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerSlime : MonoBehaviour
{
    // references for slime, portal, and spawn locations
    public Transform[] spawnLocations;
    public GameObject[] spawnPrefab;
    public GameObject[] spawnClone;
    public GameObject portal;
    public GameObject enemyCount;

    void Start()
    {
        spawnSlime(); // calls to spawn slime
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectWithTag("EnemySlime"); 
        if (enemyCount == null) // If the tag "EnemySlime" is not in the game scene, Trigger portal is called
        {
            TriggerPortal();
        }
    }

    void spawnSlime() // Spawns slime at all spawnLocations set
    {
        spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(13,0,26)) as GameObject;
        spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[1].transform.position, Quaternion.Euler(13,0,26)) as GameObject;
        spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[2].transform.position, Quaternion.Euler(13,0,26)) as GameObject;

        // Vector3 randomPos = new Vector3(spawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(13,0,26)) as GameObject;
        // Vector3 randomPos1 = new Vector3(spawnPrefab[0], spawnLocations[1].transform.position, Quaternion.Euler(13,0,26)) as GameObject;
        // Vector3 randomPos2 = new Vector3(spawnPrefab[0], spawnLocations[2].transform.position, Quaternion.Euler(13,0,26)) as GameObject;

    }

    // Activates the Portal for the next level
    void TriggerPortal()
    {

        if(portal.activeInHierarchy == false)
        {
            portal.SetActive(true);
        }
    }
}

