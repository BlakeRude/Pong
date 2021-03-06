﻿//Ball.cs
//Sets up ball behavior and scoring
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //public static int to be referenced by ScoreCount.cs
    public static int LeftScore = 0;
    public static int RightScore = 0;

    //Speed and Radius of the ball
    float speed;
    float radius;
    Vector2 Direction;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
        Direction = Vector2.one.normalized; // (1,1)
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * speed * Time.deltaTime);
        //Disallowing movement past the bottom and top walls
        if (transform.position.y < GameManager.BottomLeft.y + radius && Direction.y < 0) { Direction.y = -Direction.y; }
        if (transform.position.y > GameManager.TopRight.y - radius && Direction.y > 0) { Direction.y = -Direction.y; }

        //Point Scoring on the Left wall, and the Right wall
        if (transform.position.x < GameManager.BottomLeft.x + radius && Direction.x < 0)
        {
            transform.position = new Vector2(0, 0);
            RightScore++;
            Debug.Log("Right Score = " + RightScore);
        }
        if (transform.position.x > GameManager.TopRight.x - radius && Direction.x > 0)
        {
            transform.position = new Vector2(0, 0);
            LeftScore++;
            Debug.Log("Left Score = " + LeftScore);
        }


    }

    //OnTriggerEnter2D Unity Function with ball set to is trigger, allowing direction change when colliding with tagged Paddle
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;
            if (isRight == true && Direction.x > 0)
            {
                Direction.x = -Direction.x;
            }
            if (isRight == false && Direction.x < 0)
            {
                Direction.x = -Direction.x;
            }
        }
    }
}
