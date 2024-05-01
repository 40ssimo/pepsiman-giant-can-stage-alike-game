using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 3;
    public int score = 0;
    public bool gameOver = false;
    public bool showScore = false;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public GameObject gameOverScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        AddScoreOverTime();
        UpdateScore();
    }

    void AddScoreOverTime()
    {
        if (!gameOver)
        {
            score += 1;
        } else if (gameOver && !showScore)
        {
            Debug.Log("Score: " + score);
            showScore = true;
        }
        
    }
    
    public void CheckGameOver()
    {
        if (lives <= 0)
        {
            gameOver = true;
            Gameover();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void Gameover()
    {
        DataManager.instance.Score = score;
        if (DataManager.instance.Highscore < DataManager.instance.Score)
        {
            DataManager.instance.Highscore = score;
            DataManager.instance.HighscorePlayerName = DataManager.instance.PlayerName;
        }

        highscoreText.text = "Highscore : " + DataManager.instance.Highscore + " (" + DataManager.instance.HighscorePlayerName + ")";
        gameOverScreen.SetActive(true);
        DataManager.instance.SaveData();
    }
}
