using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 3;
    public int score = 0;
    public string playerName;
    public bool gameOver = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        AddScoreOverTime();
    }

    void AddScoreOverTime()
    {
        if (!gameOver)
        {
            score += 1;
        } else
        {
            Debug.Log("Score: " + score);
        }
        
    }
    
    public void CheckGameOver()
    {
        if (lives == 0)
        {
            gameOver = true;
        }
    }
}