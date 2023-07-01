using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 1f;


   public void loadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().resetGame();
    }

    public void loadGameOver()
    {
        StartCoroutine(waitAndLoad());
       
    }

    IEnumerator waitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
