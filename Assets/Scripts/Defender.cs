using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [Header("Defender Configuration")]
    [SerializeField] int starCost = 100;

    // Cached reference
    StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
