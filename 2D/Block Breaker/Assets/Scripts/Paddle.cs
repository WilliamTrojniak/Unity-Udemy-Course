using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //Config paramaters
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //Cache
    Ball myBall = FindObjectOfType<Ball>();
    GameStatus myGameStatus = FindObjectOfType<GameStatus>();
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(getXPos(), minX, maxX);
        transform.position = paddlePosition;
	}

    private float getXPos()
    {
        if (myGameStatus.isAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }
}
