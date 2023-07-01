using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 100;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        updateDisplay();
    }

    private void updateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void addStars(int amount)
    {
        if(stars + amount > 999)
        {
            stars = 999;
        }
        else
        {
            stars += amount;
        }
        
        updateDisplay();
    }

    public bool hasEnoughStars(int amount)
    {
        return stars >= amount;
    }

    public void removeStars(int amount)
    {
        if(stars >= amount)
        {
            stars -= amount;
            updateDisplay();
        }
        
    }


}
