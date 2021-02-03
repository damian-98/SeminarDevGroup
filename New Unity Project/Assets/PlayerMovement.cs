/*  #
    # 1: Title: "2D Movement in Unity (Tutorial)" | Author: Brackeys | Source: 	https://www.youtube.com/watch?v=dwcT-Dch0bA&list=WL&index=16&t=826s | Date retrieved: 1/27/2021 @ 9:15pm
    #
    # 
    # 2: Title: "2D Character Movement in Unity / 2021" | Author:
Distorted Pixel Studios | Source: https://www.youtube.com/watch?v=n4N9VEA2GFo&list=WL&index=26&t=2s | Date retrieved: 1/29/2021 @ 7:30pm
    #
*/


  // #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public CharacterController2D controller;// This line of code is getting Reference from the PlayerMovement script to the CharacterController2D script to move the player.
    public float runSpeed = 40f; //  Initializing the amount of speed added when the player moves.
    public float fowardMove = 0f;//  Initializing how fast the character moves.
    public bool crouch = false; // Whether or not the player is crouched.
    // ####################################################################################################################################################

    // #2: ####################################################################################################################################################
    public Rigidbody2D rb;
    public float jumpForce = 20f; //  Initializing the amount of force added when the player jumps.
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //This line of code is just calling the Rigidbody2D Component thats native to unity.
    }
    // ####################################################################################################################################################
    
     void Update()
    {  // #1: ####################################################################################################################################################
        fowardMove = Input.GetAxisRaw("Horizontal") * runSpeed; // This line of code determines how the charater moves on the horizontal axis using the left & right arrow keys.

         if(Input.GetButtonDown("Crouch")) // This code enables the down arrow key to let the charater crouch.
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) // This else if block also means if down arrow key is not pressed down to not crouch chracter.
        {
            crouch = false;
        }
        // ####################################################################################################################################################

    // #2: ####################################################################################################################################################
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f){ // This code enables the spacebar to activate chracter jump when pressed down.
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);// The code also stops charater from jumping Continuously in the air.
        }
    }
    // ####################################################################################################################################################

     void FixedUpdate()
    {
      // #1: ####################################################################################################################################################
        // Make the character move
        controller.Move(fowardMove * Time.fixedDeltaTime, crouch, false);
       
    }
    // ####################################################################################################################################################

    // #2: ####################################################################################################################################################
        // Makes character Jump 
    void Jump(){
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        
        rb.velocity = movement;
    }
}
    // ####################################################################################################################################################