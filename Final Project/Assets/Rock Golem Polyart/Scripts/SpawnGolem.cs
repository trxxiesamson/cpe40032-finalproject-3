using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGolem : MonoBehaviour
{
    public GameObject golemEnemy;
    public GameObject portal;
    public int xPos;
    public int yPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    void Update()
    {
        golemEnemy = GameObject.FindGameObjectWithTag("Golem"); // gameObject with tag "Golem"
        if (golemEnemy == null)
        {
            TriggerPortal();
        }
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 2)
        {
            xPos = Random.Range(-5, -7);
            yPos = Random.Range(0, 1);
            zPos = Random.Range(40, 42);
            Instantiate(golemEnemy, new Vector3(xPos,yPos, zPos),Quaternion.identity);
            yield return new WaitForSeconds(30.0f);
            enemyCount += 1;
        }
    }

    void TriggerPortal() // activates portal
    {

        if(portal.activeInHierarchy == false)
        {
            portal.SetActive(true);
        }

    }

}
