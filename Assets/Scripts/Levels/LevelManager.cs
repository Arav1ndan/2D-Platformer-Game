using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public string[] levels;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (GetLevelStatus(levels[0]) == levelStatus.Locked)
        {
            SetLevelStatus(levels[0], levelStatus.Unlocked);
        }
    }
    public void MarkLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, levelStatus.Completed);
        //unlock next level

        //int nextSceneIndex = currentScene.buildIndex + 1;
        //Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);

        //SetLevelStatus(nextScene.name, levelStatus.Unlocked);

        int currentSceneIndex = Array.FindIndex(levels, level => level == currentScene.name);
        int nextScenceIndex = currentSceneIndex + 1;
        if (nextScenceIndex < levels.Length)
        {
            SetLevelStatus(levels[nextScenceIndex], levelStatus.Unlocked);
        }
    }
    public levelStatus GetLevelStatus(string level)
    {
        levelStatus levelStatus = (levelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, levelStatus levelStatus )
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("setting level: " + level + "status" +  levelStatus);
    }
}
