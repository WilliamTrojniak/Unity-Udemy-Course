using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        createDefenderParent();
    }

    private void createDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        attemptToPlaceDefenderAt(getSquareClicked());
    }

    public void setSelectedDefender(Defender defenderSelection)
    {
        defender = defenderSelection;
    }

    private void attemptToPlaceDefenderAt(Vector2 gridPos)
    {
        if(defender != null)
        {
            var starDisplay = FindObjectOfType<StarDisplay>();
            int defenderCost = defender.getStarCost();

            //Check if have enough stars
            if (starDisplay.hasEnoughStars(defenderCost))
            {
                spawnDefender(gridPos);
                starDisplay.removeStars(defenderCost);
            }
        }
        

    }

    private Vector2 getSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = snapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 snapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }


    private void spawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

}
