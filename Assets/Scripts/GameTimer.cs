using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Configuration")]
    [Tooltip("Level timer in SECONDS.")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;

    // Cached Reference
    LevelController levelController;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            levelController.LevelTimerFinished();
        }
    }
}
