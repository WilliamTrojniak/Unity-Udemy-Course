using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks; //Debugging purposes

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void countBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void subtractBreakableBlock()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneLoader.nextScene();
        }
    }

}
