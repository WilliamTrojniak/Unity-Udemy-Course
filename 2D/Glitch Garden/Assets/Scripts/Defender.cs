using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int starCost = 100;

    public void addStars(int amount)
    {
        FindObjectOfType<StarDisplay>().addStars(amount);
    }

    public int getStarCost()
    {
        return starCost;
    }


}
