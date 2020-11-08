using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [Header("Stars Display Configuration")]
    [SerializeField] int stars = 100;

    // Cached Reference
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    public int GetStars()
    {
        return stars;
    }
}
