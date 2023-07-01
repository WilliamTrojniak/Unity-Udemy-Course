using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int playerLives = 3;
    [SerializeField] private int score = 0;

    [SerializeField] private Text livesText;
    [SerializeField] private Text scoreText;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }


    public void processPlayerDeath()
    {
        if(playerLives > 1)
        {
            takeLife();
        }
        else
        {
            resetGameSession();
        }
    }

    private void takeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void resetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void addToScore(int val)
    {
        score += val;
        scoreText.text = score.ToString();
    }
}
