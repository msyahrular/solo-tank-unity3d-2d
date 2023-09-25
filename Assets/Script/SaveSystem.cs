using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour
{
    public string sceneKey = "SceneIndex", savePresentKey = "SavePresentKey";//, playerHealthKey = "PlayerHealth"; 
    public LoadedData LoadedData {get; private set;}

    public UnityEvent<bool> OnDataLoadedResult;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
        var result = LoadData();
        OnDataLoadedResult?.Invoke(result);
    }

    public void ResetData()
    {
        // PlayerPrefs.DeleteKey(playerHealthKey);
        PlayerPrefs.DeleteKey(sceneKey);
        PlayerPrefs.DeleteKey(savePresentKey);
        LoadedData = null;
    }

    private bool LoadData()
    {
        if (PlayerPrefs.GetInt(savePresentKey) == 1)
        {
            LoadedData = new LoadedData();
            // LoadedData.playerHealth = PlayerPrefs.GetInt(playerHealthKey);
            LoadedData.SceneIndex = PlayerPrefs.GetInt(sceneKey);
            return true;
        }
        return false;
    }

    public void Savedata(int SceneIndex)//, int playerHealth)
    {
        if (LoadedData == null)
            LoadedData = new LoadedData();
        // LoadedData.playerHealth = playerHealth;
        LoadedData.SceneIndex = SceneIndex;
        // PlayerPrefs.SetInt(playerHealthKey, playerHealth);
        PlayerPrefs.SetInt(sceneKey, SceneIndex);
        PlayerPrefs.SetInt(savePresentKey, 1);
    }
}

public class LoadedData
{
    // public int playerHealth = -1;
    public int SceneIndex = -1;
}