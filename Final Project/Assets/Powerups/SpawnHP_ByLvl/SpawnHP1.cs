using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An object spawner
public class SpawnHP1 : MonoBehaviour
{
	// needed for spawning
	[SerializeField]
	GameObject spawnObject;

	[SerializeField]
	GameObject plane;
	
	// spawn control
	const float MinSpawnDelay = 1;
	const float MaxSpawnDelay = 5;
	Timer spawnTimer;

	// spawn location support
	float randomX;
	float randomY;
	float randomZ;

    // Use this for initialization
    void Start()
    {
		plane = GameObject.FindWithTag("Plane");

		// save spawn boundaries for efficiency
		float randomX = Random.Range (19, 6);
		float randomY = Random.Range (0.676f, 0.676f);
		float randomZ = Random.Range (31, 21);

		// create and start timer
		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
		spawnTimer.Run();
	}

    // / Update is called once per frame
    void Update()
    {
		// check for time to spawn a new enemy
		if (spawnTimer.Finished)
        {
			objectSpawn();

			// change spawn timer duration and restart
			spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
			spawnTimer.Run();
		}
		
	}
	
	// Spawns an object at a random location on a plane
	void objectSpawn()
	{
		// generate random location and create new object
		Vector3 randomPosition = GetARandomPos(plane);
                                                                  
        Instantiate<GameObject>(spawnObject, randomPosition, Quaternion.identity);   
	
	}


	// Return random position on the plane

	public Vector3 GetARandomPos(GameObject plane)
	{
    Mesh planeMesh = plane.GetComponent<MeshFilter>().mesh;
    Bounds bounds = planeMesh.bounds;

    float minX = 19;
	float minY = 0.676f;
    float minZ = 31;

    Vector3 newVec = new Vector3(Random.Range (minX, 6), minY, Random.Range (minZ, 21));
    return newVec;
	} 
}

