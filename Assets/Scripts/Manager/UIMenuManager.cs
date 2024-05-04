using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{
    public TMP_Text highscoreText;
    public TMP_InputField inputName;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        DataManager.instance.LoadData();
        if (DataManager.instance.Highscore == 0)
        {
            DataManager.instance.PlayerName = "Anonymous";
        }
        
        LatestHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        AudioManager.instance.PlaySound(audioSource, AudioManager.instance.audioList[5]);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        AudioManager.instance.PlaySound(audioSource, AudioManager.instance.audioList[5]);

        DataManager.instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void LatestHighscore()
    {
        if (DataManager.instance.Highscore != 0)
        {
            highscoreText.text = "Highscore : " + DataManager.instance.Highscore + " (" + DataManager.instance.HighscorePlayerName + ")";
        }
        else
        {
            highscoreText.text = "Highscore : " + 0 + " (Anonymous)";
        }
        
    }

    public void InsertName()
    {
        DataManager.instance.PlayerName = inputName.text;
        Debug.Log("Player with name " + DataManager.instance.PlayerName + " has entered the game");

    }
}