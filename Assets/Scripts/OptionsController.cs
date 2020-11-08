using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    // Configuration parameters
    [Header("Options Configuration")]
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = .8f;
    [SerializeField] Slider difficultSlider;
    [SerializeField] float defaultDifficulty = 0f;

    // Cached Reference
    MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultSlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultSlider.value);
        FindObjectOfType<LevelLoader>().LoadStartMenuScene();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultSlider.value = defaultDifficulty;
    }
}