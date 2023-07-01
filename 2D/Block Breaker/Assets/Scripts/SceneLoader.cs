using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void nextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.resetGame();

    }
    public void exitApplication()
    {
        Application.Quit();
    }
}
