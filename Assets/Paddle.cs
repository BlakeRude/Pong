//Paddle.cs
//Set up left and right paddle behaviors and bounds
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float speed;
    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        //start by delaring the height and speed of the ball.
        height = transform.localScale.y;
        speed = 10f; //difficulty setting possibility in the future? allow this to be user adjustable*
    }

    //Init function for creating left and right paddles. Takes a bool to determine if it is left or right. Public so it can be used by GameManager.cs
    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 Position = Vector2.zero;
        if (isRightPaddle)
        {
            //If its a Right paddle, initialize to the right
            Position =  new Vector2(GameManager.TopRight.x, 0);
            Position -= Vector2.right * transform.localScale.x;
            input = "PaddleRight";
        }
        else
        {
            //If not Right paddle, initialize to the left
            Position = new Vector2(GameManager.BottomLeft.x, 0);
            Position += Vector2.right * transform.localScale.x;
            input = "PaddleLeft";
        }
        //transform position and name based on which Paddle was initialized
        transform.position = Position;
        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        //Move based on inputs: ad for right left right for left. Multiplied by Time.deltaTime to run independent of framerate
        //multiplied by speed for the speed to be easily adjusted.
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        //set bounds for the top and bottom walls, if at bounds, no movement
        if (transform.position.y < GameManager.BottomLeft.y + height / 2 && move < 0) { move = 0; }
        if (transform.position.y > GameManager.TopRight.y - height/2 && move > 0) { move = 0; }
        transform.Translate(move * Vector2.up);
    }
}
