using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    // Cached References
    Animator animator;
    Attacker attacker;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.name.Contains("Gravestone"))
            {
                animator.SetTrigger("jumpTrigger");
                return;
            }

            attacker.Attack(otherObject);
        }
    }
}
