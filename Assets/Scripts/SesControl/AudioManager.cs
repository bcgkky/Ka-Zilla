using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip startGameSound; // Butona tıklandığında çalacak ses dosyası
    public Slider volumeSlider;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Oyun başladığında belirtilen ses dosyasını çal
        PlayStartGameSound();

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    void PlayStartGameSound()
    {
        // AudioClip atanmışsa ve audioSource mevcutsa ses dosyasını çal
        if (startGameSound != null && audioSource != null)
        {
            audioSource.clip = startGameSound;
            audioSource.Play();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
