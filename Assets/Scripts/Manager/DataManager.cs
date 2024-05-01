using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataManager instance;
    [SerializeField] private string playerName;
    [SerializeField] private string score;
   
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public string Score
    {
        get { return score; }
        set { score = value; }
    }

    public DataManager(string playerName, string score)
    {
        this.playerName = playerName;
        this.score = score;
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

}
