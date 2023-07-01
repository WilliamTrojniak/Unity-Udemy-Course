using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject deathVFX;

    public void dealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        triggerDeathVFX();
        Destroy(gameObject);
    }

    private void triggerDeathVFX()
    {
        if (!deathVFX)
        {
            Debug.Log("No VFX on: " + gameObject.name);
        }
        else
        {
            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(deathVFXObject, 1f);
        }
    }

}
