using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //Config
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int pointsUponDestroy = 100;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit = 0;
    

    private void Start()
    {
        tallyTotalBreakableBricks();

    }

    private void tallyTotalBreakableBricks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.countBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            handleHit();
        }
    }

    private void handleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length;
        if (timesHit >= maxHits)
        {
            destroyBlock();
        }
        else
        {
            showNextHitSprite();
        }
    }

    private void showNextHitSprite()
    {
        int spriteIndex = timesHit;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array" + gameObject.name);
        }
    }

    private void destroyBlock()
    {
        FindObjectOfType<GameStatus>().addToScore(pointsUponDestroy);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.subtractBreakableBlock();
        triggerSparklesVFX();
        Destroy(gameObject);
    }

    private void triggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
