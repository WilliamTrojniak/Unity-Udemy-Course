using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;


    int numberOfAttackers = 0;
    bool levelTimerFinished = false;


    private void Start()
    {
        if(winLabel != null && loseLabel != null)
        {
            winLabel.SetActive(false);
            loseLabel.SetActive(false);
        }
        
    }


    public void attackerSpawned()
    {
        numberOfAttackers++;
    }

    public void attackerKilled()
    {
        numberOfAttackers--;

        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(handleWinCondition());
        }
    }

    IEnumerator handleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }


    public void handleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }


    public void levelTimerHasFinished()
    {
        levelTimerFinished = true;
        stopSpawners();
    }

    private void stopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.stopSpawning();
        }
    }
}
