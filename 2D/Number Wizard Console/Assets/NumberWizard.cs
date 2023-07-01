using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;

	// Use this for initialization
	void Start () {

        startGame();
        
	}
	
    void startGame()
    {
        max = 1000;
        min = 1;
        guess = 500;
        Debug.Log("Welcome to number wizard");
        Debug.Log("Pick a number between " + min + " and " + max + ", and I'll try to guess it");
        Debug.Log("**Controls: UP Arrow: Higher, DOWN Arrow: Lower, SPACE: Correct**");
        Debug.Log("Is your number higher or lower than " + guess + "?");
        max++;
    }


	// Update is called once per frame
	void Update ()
    {
        takeInput();

    }

    private void takeInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            nextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            nextGuess();

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Woohoo! Got it!");
            Debug.ClearDeveloperConsole();
            startGame();
        }
    }

    void nextGuess()
    {
        guess = (max + min) / 2;
        Debug.Log(guess);
    }
}
