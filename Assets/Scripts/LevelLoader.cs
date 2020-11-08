using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Timer Configuration")]
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScene());
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void LoadStartMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }
}
