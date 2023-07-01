using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private AudioClip coinPickUpSFX;
    [SerializeField] private int scoreValue = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().addToScore(scoreValue);
        
    }
}
