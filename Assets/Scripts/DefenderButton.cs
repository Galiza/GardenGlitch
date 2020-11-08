using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [Header("Defender Configuration")]
    [SerializeField] Defender defenderPrefab;
    StarDisplay starDisplay;
    Text costText;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        costText = GetComponentInChildren<Text>();
        if (!costText) { return; }
        costText.text = defenderPrefab.GetStarCost().ToString();
    }

    private void Update()
    {
        if (!costText) { return; }
        if (starDisplay.GetStars() < defenderPrefab.GetStarCost())
        {
            costText.color = new Color32(96, 94, 44, 255);
        }
        else
        {
            costText.color = new Color32(255, 242, 0, 255);
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawn>().SetSelectedDefender(defenderPrefab);
    }
}
