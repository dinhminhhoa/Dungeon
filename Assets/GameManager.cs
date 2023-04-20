using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager>
{
    private int Gold = 0;
    public int Goldd => Gold;

    private bool isPlaying = false;
    public bool IsPlaying => isPlaying;
    public void UpdateGold(int v)
    {
        Gold = v;
    }
    public void StartGame()
    {
        isPlaying = true;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (isPlaying)
        {
            isPlaying = false;
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        isPlaying = true;
        Time.timeScale = 1f;
    }

    public void RestarGame()
    {
        Gold = 0;
        ChangeScene("Menu");

        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveMenuPanel(true);
            //UIManager.Instance.ActiveHealthBarPanel(false);
            UIManager.Instance.ActiveGamePanel(false);                          
            UIManager.Instance.ActiveVictoryPanel(false);
            UIManager.Instance.ActiveLosePanel(false);
            UIManager.Instance.GamePanel.NumberOfCherries.SetText("0");
        }
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
