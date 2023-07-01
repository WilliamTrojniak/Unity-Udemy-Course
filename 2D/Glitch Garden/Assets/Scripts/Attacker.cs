using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range (0f, 5f)]
    private float currentSpeed = 0f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().attackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.attackerKilled();
        }

    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        updateAnimationState();
    }

    private void updateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void setMoveSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void strikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return;  }
        Health health = currentTarget.GetComponent<Health>();

        if (health)
        {
            health.dealDamage(damage);
        }
    }

}
