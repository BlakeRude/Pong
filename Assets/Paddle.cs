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
        height = transform.localScale.y;
        speed = 10f;
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 Position = Vector2.zero;
        if (isRightPaddle)
        {
            //initialize to the right
            Position =  new Vector2(GameManager.TopRight.x, 0);
            Position -= Vector2.right * transform.localScale.x;
            input = "PaddleRight";
        }
        else
        {
            //initialize to the left
            Position = new Vector2(GameManager.BottomLeft.x, 0);
            Position += Vector2.right * transform.localScale.x;
            input = "PaddleLeft";
        }
        transform.position = Position;
        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        if (transform.position.y < GameManager.BottomLeft.y + height / 2 && move < 0) { move = 0; }
        if (transform.position.y > GameManager.TopRight.y - height/2 && move > 0) { move = 0; }
        transform.Translate(move * Vector2.up);
    }
}
