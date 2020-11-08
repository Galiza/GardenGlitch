using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    // Cached Reference
    Attacker attacker;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            attacker.Attack(otherObject);
        }
    }
}
