using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string PlayerName;
    public string BestPlayer;
    public int HighScore;
    public TMP_InputField NameText;
    public TextMeshProUGUI ScoreText;

    public void NewNameSelected()
    {
        // add code here to handle when a name is selected
        DataManager.Instance.CurrentPlayer = NameText.text;
    }
    
    private void Start()
    {
        DataManager.Instance.LoadScore();
        PlayerName = DataManager.Instance.CurrentPlayer;
        BestPlayer = DataManager.Instance.BestPlayer;
        HighScore = DataManager.Instance.HighScore;
        NameText.text = PlayerName;
        ScoreText.text = BestPlayer + " | " + HighScore;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif

        DataManager.Instance.SaveScore();
    }
}
