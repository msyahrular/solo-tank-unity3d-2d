using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SaveSystem saveSystem;

    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
        DontDestroyOnLoad(gameObject);
    }

    private void Initialize(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("Loaded GM");
        var playerInput = FindObjectOfType<PlayerInput>();
        if ( playerInput != null)
            player = playerInput.gameObject;
        saveSystem = FindObjectOfType<SaveSystem>();
        // if (player != null && saveSystem.LoadedData != null)
        // {
        //     var damageable = player.GetComponentInChildren<Damageable>();
        //     damageable.Health = saveSystem.LoadedData.playerHealth;
        // }
    }

    public void LoadLevel()
    {
        if (saveSystem.LoadedData != null)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(saveSystem.LoadedData.SceneIndex);
            return; 
        }
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveData()
    {
        if (player != null)
            saveSystem.Savedata(SceneManager.GetActiveScene().buildIndex + 1);
            // player.GetComponentInChildren<Damageable>().Health);

    }

    public void ResetData()
    {
        saveSystem.ResetData();
    }

    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
