using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public InputField userInput;
    public Text highScore;

    public void Awake()
    {
        highScore.text = NewManager.HighScoreText;
    }
    public void AcceptName()
    {
        NewManager.playerName = userInput.text;
    }
    public void StartGame()
    {
        AcceptName();
        SceneManager.LoadScene(1);
        Debug.Log("The name " + NewManager.playerName + " is assigned.");
    }

    public void Exit()
    {
        NewManager.Instance.SaveScore();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
