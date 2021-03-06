﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // Configuration Parameters
    float currentSpeed = 1f;

    // Cached Reference
    GameObject currentTarget;
    Animator animator;
    LevelController levelController;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        levelController.AttackerSpawned();

        animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        if (levelController == null) { return; }
        levelController.AttackerKilled();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
