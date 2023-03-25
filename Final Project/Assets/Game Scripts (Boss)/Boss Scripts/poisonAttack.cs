using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonAttack : MonoBehaviour
{
    //poison prefab values
    public float speed;
    private float shotLife = 3.5f;
    private int bossDamage = 35;

    //prefab's references
    private Transform player;
    private Vector3 target;
    //prefab's components
    private SphereCollider poisonCollider;
    private Rigidbody poisonRb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;      //referencing the player's position
        target = new Vector3(player.position.x, player.position.y);

        poisonCollider = GetComponent<SphereCollider>();
        poisonCollider.isTrigger = true;

        poisonRb = GetComponent<Rigidbody>();
        poisonRb.isKinematic = true;
        Destroy(this.gameObject, shotLife);         //destroys the attack when it didn't hit the player

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);      //allows the attack to go straight
        if (transform.position.x == target.x && transform.position.y == target.y)   //destroys when reaches the player's position
        {
            DestroyProjectile();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject)
            {
                Controller playerHealth = other.GetComponent<Controller>();     //accessing player's health
                playerHealth.TakeDamage(bossDamage);
            }
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
