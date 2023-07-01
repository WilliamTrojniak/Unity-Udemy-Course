using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] Text guessText;

    int guess;

	// Use this for initialization
	void Start () {

        startGame();
        
	}
	
    void startGame()
    {
        nextGuess();
        
    }

    public void onPressHigher()
    {
        min = guess+1;
        nextGuess();
    }

    public void onPressLower()
    {
        max = guess -1;
        nextGuess();
    }

    void nextGuess()
    {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }
}
