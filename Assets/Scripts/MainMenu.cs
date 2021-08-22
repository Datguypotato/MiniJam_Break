using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject options;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioSource Audio;
    private string musicKey = "Music";

    private void Start()
    {
        GoMain();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoMain()
    {
        main.SetActive(true);
        options.SetActive(false);
    }

    public void GoOptions()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    // on value change from slider
    public void AssignMusic()
    {
        PlayerPrefs.SetFloat(musicKey, musicSlider.value);
        Audio.volume = musicSlider.value;
    }
}