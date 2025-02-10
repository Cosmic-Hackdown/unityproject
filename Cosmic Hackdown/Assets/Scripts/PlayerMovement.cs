using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator anim;

    private bool grounded;

    //SerializeField allows you to edit the speed directly from Unity
    [SerializeField] private float speed;

    //called every time you start the game aka script being loaded
    private void Awake()
    {
        //checks player object for type rigidbody2d.
        //player has type rigidbody2d as you can see in its inspector so it will take its rigidbody2d
        //and store into the body variable
        body = GetComponent<Rigidbody2D>();
        //reference for animator component
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        /*Vector3 is a collection of numbers to assign speed in all 3 directions:
        1. left and right
        2. up and down
        3. backwards and forward
        But we are using Vector2 instead bc this game is 2D not 3D!

        Input.GetAxis("Horizontal") is designed by Unity already. Every time you press left button
        (A key) it goes to -1. Every time you press the right button (D key) it goes to +1.

        body.velocity.y means you don't want to change value on the y axis. 
        */
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        /*
        This is to make your character JUMP
        KeyCode is an enumeration that contains all buttons.  
        Use KeyCode.Enter to check if enter was pressed, etc.  In this case, we check
        if space was pressed or not.  It also checks if it's grounded.
        character will only jump if it is on the ground, making it so you can't do infinite jumps.
        */
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            /*
            So if space bar is pressed, we do the following below:
            set the body's velocity to the speed variable and only update this for the y axis.
            x axis is body.velocity.x because you don't want to check its value.
            This is to make your character JUMP up (which is why we need to change the y axis
            but not the x axis)
            */
            Jump();
        }

        //Set animator parameters
        //is 0 not equal to 0? false.  so it plays the idle animation.  But if there is horizontal input, this will evaluate to true.
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {

        body.velocity = new Vector2(body.velocity.x, speed * 1.7f);
        grounded = false;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

}
