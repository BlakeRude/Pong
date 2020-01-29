//GameManager.cs
//Honestly don't know why I had to name it this for it to work but I guess thats just how it works
//Defines ball and paddle, sets bounds based on camera, instantiates ball, left and right paddles. 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //define our paddle and ball class variables, as well as our bounds vectors
    public Paddle paddle;
    public Ball ball;
    public static Vector2 BottomLeft;
    public static Vector2 TopRight;

    // Start is called before the first frame update
    void Start()
    {
        //Define Bounds using Camera coordinates
        BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //Instantiate Ball
        Instantiate (ball);
        //Instantiate Left and Right Paddles
        Paddle paddleR = Instantiate(paddle) as Paddle;
        Paddle paddleL = Instantiate(paddle) as Paddle;
        paddleR.Init(true); // right
        paddleL.Init(false);  //left
    }

    // Update is called once per frame
    void Update()
    {
        //You wanted this so you could exit the program :)
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
