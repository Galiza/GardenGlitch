using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsDisplay : MonoBehaviour
{
    [Header("Hit Points Configuration")]
    [SerializeField] float baseHitPoints = 3;
    [SerializeField] int damage = 1;
    float hitPoints;

    // Cached reference
    Text text;
    LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = baseHitPoints - PlayerPrefsController.GetDifficulty();
        levelController = FindObjectOfType<LevelController>();
        text = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        text.text = hitPoints.ToString();
    }

    public void TakeLife()
    {
        hitPoints -= damage;
        UpdateDisplay();

        if (hitPoints <= 0)
        {
            levelController.HandleLoseCondition();
        }
    }

}
