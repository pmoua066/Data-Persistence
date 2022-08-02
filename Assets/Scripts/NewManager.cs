using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NewManager : MonoBehaviour
{
    public static NewManager Instance;

    public static string playerName;

    public static int HighScorePoints;
    public static string HighScoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }


    public void SaveUsername(string newName)
    {
        playerName = newName;
    }

    [System.Serializable]

    class SaveData
    {
        public string HighScoreText;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScoreText = HighScoreText;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Score is saved");
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("Score is found.");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreText = data.HighScoreText;
        }
    }
}
