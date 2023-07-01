using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    

    State state;
    
    // Use this for initialization
	void Start () {
        state = startingState;
        textComponent.text = state.getStateStory();
        
	}
	
	// Update is called once per frame
	void Update () {
        manageState();
        
	}

    private void manageState()
    {
        State[] nextStates = state.getNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextStates[0];
        }else if (Input.GetKeyDown(KeyCode.Alpha2) && nextStates.Length >1 )
        {
            state = nextStates[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && nextStates.Length > 2)
        {
            state = nextStates[2];
        }
        textComponent.text = state.getStateStory();
    }
}
