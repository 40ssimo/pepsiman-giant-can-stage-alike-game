using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataManager instance;
    [SerializeField] private string playerName;
    [SerializeField] private int score;
    [SerializeField] private string highscorePlayerName;
    [SerializeField] private int highscore;
    public bool gravityHasChanged = false;
   
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public int Highscore
    {
        get { return highscore; }
        set { highscore = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public string HighscorePlayerName
    {
        get { return highscorePlayerName; }
        set { highscorePlayerName = value; }
    }

    public DataManager(string playerName, int highscore, bool gravityHasChanged, int score, string highscorePlayerName)
    {
        this.playerName = playerName;
        this.highscore = highscore;
        this.score = score;
        this.gravityHasChanged = gravityHasChanged;
        this.highscorePlayerName = highscorePlayerName;
    }

    //Singleton Pattern Init;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveInfo
    {
        public int highscore;
        public string playerName;
    }

    public void SaveData()
    {
        if (NewHighscore())
        {
            SaveInfo data = new SaveInfo();
            data.playerName = DataManager.instance.HighscorePlayerName;
            data.highscore = DataManager.instance.Highscore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savedatapepsi.json", json);
            Debug.Log(Application.persistentDataPath + "/savedatapepsi.json");
        }
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedatapepsi.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveInfo data = JsonUtility.FromJson<SaveInfo>(json);

            DataManager.instance.highscore = data.highscore;
            DataManager.instance.HighscorePlayerName = data.playerName;
        }
    }

    public bool NewHighscore()
    {
        string path = Application.persistentDataPath + "/savedatapepsi.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveInfo data = JsonUtility.FromJson<SaveInfo>(json);

            if (DataManager.instance.highscore > data.highscore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public SaveInfo GetData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        DataManager.SaveInfo data = new DataManager.SaveInfo();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<DataManager.SaveInfo>(json);
        }

        return data;
    }

}
