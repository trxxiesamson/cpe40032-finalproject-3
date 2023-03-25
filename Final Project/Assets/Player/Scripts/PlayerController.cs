using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //component
    public CharacterController player;
    private Animator playerAnim;
    public GameObject attackPrefab;

    //mesh
    private Transform meshPlayer;

    //movement
    private float forward;
    private float turn;
    private Vector3 playerMove;
    private float moveSpeed;
    private float gravity;
    

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.1f;
        gravity = 0.5f;
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tempPlayer.transform.GetChild(0);
        player = tempPlayer.GetComponent<CharacterController>();
        playerAnim = meshPlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetAxis("Horizontal");
        turn = Input.GetAxis("Vertical");

        if(forward == 0 && turn == 0)
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
    }
    private void FixedUpdate()
    {
        //gravity
        if (player.isGrounded)
        {
            playerMove.y = 0f;
        }
        else
        {
            playerMove.y -= gravity * Time.deltaTime;
        }

        //movement
        playerMove = new Vector3(forward * moveSpeed, 0, turn * moveSpeed);
        player.Move(playerMove);

        //rotation
        if (forward != 0 || turn != 0)
        {
            Vector3 lookDir = new Vector3(playerMove.x, 0, playerMove.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
        
    }
}
