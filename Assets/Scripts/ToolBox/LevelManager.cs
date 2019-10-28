using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool inGame = false;
    public string nextScene;

    private string currentScene;

    PlayerController myPlayer = null;

    private void Awake()
    {
        SceneManager.activeSceneChanged += newScene;
        currentScene = SceneManager.GetActiveScene().name;
        nextScene = "Level1";
    }


    public void loadNextScene()
    {
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
    }

    public void resetScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    private void newScene(Scene current, Scene next)
    {
        myPlayer = FindObjectOfType<PlayerController>();
        currentScene = next.name;
        inGame = currentScene.Contains("Level");
    }
}
