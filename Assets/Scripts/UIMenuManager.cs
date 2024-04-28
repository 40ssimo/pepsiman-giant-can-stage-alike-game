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
    // Start is called before the first frame update
    void Start()
    {
        LatestHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void LatestHighscore()
    {
        highscoreText.text = "Highscore : 2000 (Anonymous)";
    }

    public void InsertName()
    {
        DataManager.instance.PlayerName = inputName.text;
        Debug.Log("Player with name" + DataManager.instance.PlayerName + "has entered the game");

    }
}