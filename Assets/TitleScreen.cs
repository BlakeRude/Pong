//TitleScreen.cs
//Sets up anything I need in the Title Screen.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    //string for what scene we want to load when pressing start button
    private string GameScene = "Pong";
    
    //Function assigned to the Start Button on the Title Screen to load Pong game
    public void StartGame()
    {
        //Loads scene "Pong"
        SceneManager.LoadScene(GameScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
