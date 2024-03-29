using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private string musicKey = "Music";
    private AudioSource Audio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Audio = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey(musicKey))
            Audio.volume = PlayerPrefs.GetFloat(musicKey);
    }
}