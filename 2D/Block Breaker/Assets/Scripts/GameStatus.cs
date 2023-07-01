using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    //Config
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] Text scoreText;
    [SerializeField] bool enableAutoPlay = false;

    //state
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
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
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void addToScore(int pointsToAdd)
    {
        currentScore += pointsToAdd;
        scoreText.text = currentScore.ToString();
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }

    public bool isAutoPlayEnabled()
    {
        return enableAutoPlay;
    }
}
