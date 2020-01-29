//ScoreCount.cs
//Displays the score for the game in the pong scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{

    public Text Scoreboard;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //updates scoreboard with scores which are updated within Ball.cs
        Scoreboard.text = Ball.LeftScore.ToString() + "          -          " + Ball.RightScore.ToString();
    }
}