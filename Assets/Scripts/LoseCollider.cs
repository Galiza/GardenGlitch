using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    // Cached Reference
    HitPointsDisplay hitPointsDisplay;

    // Start is called before the first frame update
    void Start()
    {
        hitPointsDisplay = FindObjectOfType<HitPointsDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        hitPointsDisplay.TakeLife();
        Destroy(otherCollider.gameObject);
    }
}
