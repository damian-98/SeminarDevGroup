/*  # 1: Title: "2D Character Movement in Unity / 2021" | Author: Distorted Pixel Studios | Source: https://www.youtube.com/watch?v=n4N9VEA2GFo&list=WL&index=26&t=2s | Date retrieved: 1/29/2021 @ 7:30pm
    #
    # 
    # 2: Title: "HOLD JUMP KEY TO JUMP HIGHER - 2D PLATFORMER CONTROLLER - UNITY TUTORIAL" | Author: Blackthornprod | Source: https://www.youtube.com/watch?v=j111eKN8sJw&list=WL&index=28 | Date retrieved: 2/3/2021 @ 2:05pm
    #
*/

// #2: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    private Rigidbody2D rb;
    public float speed; // Initializing how fast the player moves.
    public float jumpForce; //  Initializing the amount of force added when the player jumps.
    private float moveInput; // This code detects Weather the user is holding down the left or right arrow keys.
    private bool isGrounded; // Checks if player is on the ground.
    public Transform feetPos; // This code will detect if the players feet is on the ground so it can jump.
    public float checkRadius; // This code just enables the  user to change how large they want the radius around the players feet to be.
    public LayerMask whatIsGround; //  Initializing what will be consider solid ground for the player to move on.
    private float jumpTimeCounter; // This code is used as a Increment of how many times the user jumps.
    public float jumpTime; //  Initializing the amount of pressure holding down the spacebar to make player jump higher.
    private bool isJumping; // Checks if player is jumping.

    void Start(){
        rb = GetComponent<Rigidbody2D>(); //This line of code is just calling the Rigidbody2D Component which is attached to my player.
    }

    void FixedUpdate(){
        moveInput = Input.GetAxisRaw("Horizontal"); // This line of code determines how the charater moves on the horizontal axis using the left & right arrow keys.

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // This code implements speed to the player.
    }

    void Update(){
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(moveInput > 0){ 
            transform.eulerAngles = new Vector3(0, 0, 0); // This code enables the player to face right when user is moving right.
        }
        else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0, 180, 0); // This code enables the player to face left when user is moving left.
        }
        // #1: ####################################################################################################################################################
         if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f){ // This code enables the spacebar to activate chracter jump when pressed down.
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);// The code also stops charater from jumping Continuously in the air.
        // ####################################################################################################################################################
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
         }

        if(Input.GetKey(KeyCode.Space) && isJumping == true){ // This code checks how long the user is holding down the spacebar.

            if(jumpTimeCounter > 0){ // This if block is saying if jumpTimeCounter is greater than 0 then the player can keep jumping higher.
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;// Also this piece of code will The deincrement the jumpTimeCounter so that the player falls to the ground.
            }
            else{
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)){ // This if block just detects if the player is holding down on spacebar if not then player will not jump.
            isJumping = false;
        }

    }
}
// ####################################################################################################################################################