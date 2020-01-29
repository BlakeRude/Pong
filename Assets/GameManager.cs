using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Paddle paddle;
    public Ball ball;

    public static Vector2 BottomLeft;
    public static Vector2 TopRight;
    // Start is called before the first frame update
    void Start()
    {
        // Make the game camera coordinates usable for our game
        BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Instantiate (ball);
        //Instantiate (paddle);

        // Instantiate two paddles
        Paddle paddleR = Instantiate(paddle) as Paddle;
        Paddle paddleL = Instantiate(paddle) as Paddle;
        paddleR.Init(true); // right
        paddleL.Init(false);  //left
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
