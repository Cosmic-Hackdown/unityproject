using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;

    //SerializeField allows you to edit the speed directly from Unity
   [SerializeField] private float speed;

    //called every time you start the game aka script being loaded
    private void Awake() {
        //checks player object for type rigidbody2d.
        //player has type rigidbody2d as you can see in its inspector so it will take its rigidbody2d
        //and store into the body variable
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        /*Vector3 is a collection of numbers to assign speed in all 3 directions:
        1. left and right
        2. up and down
        3. backwards and forward
        But we are using Vector2 instead bc this game is 2D not 3D!

        Input.GetAxis("Horizontal") is designed by Unity already. Every time you press left button
        (A key) it goes to -1. Every time you press the right button (D key) it goes to +1.

        body.velocity.y means you don't want to change value on the y axis. 
        */
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);

        /*
        This is to make your character JUMP
        KeyCode is an enumeration that contains all buttons.  
        Use KeyCode.Enter to check if enter was pressed, etc.  In this case, we check
        if space was pressed or not.
        */
        if(Input.GetKey(KeyCode.Space)) {
            /*
            So if space bar is pressed, we do the following below:
            set the body's velocity to the speed variable and only update this for the y axis.
            x axis is body.velocity.x because you don't want to check its value.
            This is to make your character JUMP up (which is why we need to change the y axis
            but not the x axis)
            */
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }

    // Start is called before the first frame update
   /* void Start()
    {
        
    }

     */


}
