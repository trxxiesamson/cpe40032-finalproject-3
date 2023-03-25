using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3_SpawnSlime : MonoBehaviour
{
    // Reference to the gameObjects and spawn locations
    public Transform[] spawnLocations;
    public GameObject[] spawnPrefab;
    public GameObject[] spawnClone;


    void Start()
    {
        spawnSlime(); // call on the spawn slime
    }

    void Update()
    {

    }


    void spawnSlime() // This spawns the slime at all the spawnLocations set
    {
        spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[1].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[2].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[3].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        spawnClone[0] = Instantiate(spawnPrefab[0], spawnLocations[4].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
    }
}
