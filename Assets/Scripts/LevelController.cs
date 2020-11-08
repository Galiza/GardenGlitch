using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Level Controller Configuration")]
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    [Header("Sound Configuration")]
    [SerializeField] AudioClip winSFX;
    [Range(0, 1)] float winSFXVolume = 0.75f;

    // Cached Reference
    LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position, winSFXVolume);
        winLabel.SetActive(true);
        yield return new WaitForSeconds(waitToLoad);
        levelLoader.LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    public void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
