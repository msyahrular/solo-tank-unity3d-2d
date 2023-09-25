using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinOnKill : MonoBehaviour
{
    GameManager gameManager;
    public GameObject killScore;
    public int Score;
    public int JumlahPlayer;
    public GameObject WinPanel;
    public GameObject GameOverPanel;
    public GameObject TabelPause;
    public Button Music;
    public Sprite[] spriteMute;

    public void KillEnemyCount()
    {
        Score--;
        killScore.GetComponent<Text>().text = "Enemies:"  + Score;

        if(Score == 0)
        {
            Time.timeScale = 0;
            WinPanel.SetActive(true);
        }
    }

    public void PlayerDeath()
    {
        JumlahPlayer--;
        if(JumlahPlayer == 0)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
            
    }

    public void NextLevelFun()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PanelPause()
    {
        if(Time.timeScale == 1)
        {
            TabelPause.SetActive (true);
            Time.timeScale = 0;
        }
        else
        {
        TabelPause.SetActive (false);
        Time.timeScale = 1;
        }
        
        
    }

    
}
