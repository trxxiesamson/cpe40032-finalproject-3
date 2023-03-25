using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //Values used for Controls
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = 3;
    private float hInput;
    private float vInput;
    public float HP = 1000;

    //Player's Components
    CharacterController playerController;
    private Animator playerAnim;
    private Transform meshPlayer;
    private Vector3 moveDirection = Vector3.zero;
    public AudioSource playerAudio;
    public AudioSource fireAudio;
    public AudioSource iceAudio;
    public Slider healthBar;

    public bool gameHasEnded = false;
    public GameOverScreen GameOverScreen;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tempPlayer.transform.GetChild(0);      //getting the mesh of the empty game object Player
        playerController = tempPlayer.GetComponent<CharacterController>();      //accessing the player's character controller
        playerAnim = meshPlayer.GetComponent<Animator>();       //getting the animator for the mesh as the main player is empty
    }

    private void Update()
    {
        healthBar.value = HP;       //setting the slider's value as the HP 
        if (playerController.isGrounded)
        {
            hInput = Input.GetAxis("Horizontal");
            vInput = Input.GetAxis("Vertical");
            moveDirection = new Vector3(hInput, 0, vInput);  
            moveDirection *= speed;  //multiplying the speed wherever the player goes according to the input
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))  //while the user presses the keys, the footsteps plays
            {
                playerAudio.enabled = true;
            }
            else
            {
                playerAudio.enabled = false;
            }
            
        }
        if (hInput == 0 && vInput == 0)     //animations
        {
            playerAnim.SetBool("isRun", false);
        }
        else
        {
            playerAnim.SetBool("isRun", true);
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            playerAnim.SetTrigger("isAttacking");
        }

        moveDirection.y -= gravity;     //character controller already has a rigidbody, thus it has a gravity component
        playerController.Move(moveDirection * Time.deltaTime);  

        if (hInput != 0 || vInput != 0)     //enables the player to stop its direction according to its input
        {
            Vector3 lookDir = new Vector3(moveDirection.x, 0, moveDirection.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
    }

    public void FireSound()     //fireball sfx
    {
        fireAudio.enabled = false;
        if (Input.GetKeyDown(KeyCode.E))
        {
            fireAudio.enabled = true;
        }
    }
    public void IceSound()      //ice sfx
    {
        iceAudio.enabled = false;
        if (Input.GetKeyDown(KeyCode.Q))
        {
           iceAudio.enabled = true;
        }
    }

    // Damage dealth to the player, animation of death and getting hit will run here
    public void TakeDamage(float damageAmount)      //player's health component
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            playerAnim.SetTrigger("Death");
            gameHasEnded = true;
            FindObjectOfType<SoundEffects>().DeathSound(); // Plays Game Over sound effect
            GameOverScreen.GameIsOver(); // Activates the gameOver screen
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
        }
        else
        {
            AudioManager.instance.Play("SlimeDamage");
            playerAnim.SetTrigger("Hit");
        }
    }

}
