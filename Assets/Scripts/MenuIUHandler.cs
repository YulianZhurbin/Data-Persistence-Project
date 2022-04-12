using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuIUHandler : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text typeInYourNameText;
    [SerializeField] Text bestScoreText;
    private string bestPlayerName;
    private int bestScore;

    void Start()
    {
        LoadBestScore();
        bestScoreText.text = $"Best Score - {bestPlayerName}: {bestScore}";
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            bestScore = data.score;
        }
    }

    public void OnSelect() 
    {
        typeInYourNameText.text = "";
    }

    public void OnEndEdit()
    {
        BetweenSceneStorage.instance.storedName = nameText.text;
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
    }
}
