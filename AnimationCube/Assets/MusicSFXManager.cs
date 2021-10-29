using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSFXManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource[] sfxSources;
    [SerializeField] private Toggle musicToggle;
    private float preMusicVolume;
    //[SerializeField] private Toggle soundToggle;

    public void Start()
    {
        musicSlider.value = MainMenuManager.instance.playerData.musicVolume;
        soundSlider.value = MainMenuManager.instance.playerData.soundVolume;

        if (MainMenuManager.instance.playerData.isMusicOn == true)
        {
            musicToggle.isOn = true;
            onMusicToggleChanged(true);
        }
        else
        {
            musicToggle.isOn = false;
            onMusicToggleChanged(false);
        }
    }
    public void onMusicVolumeChanged(float value)
    {
        preMusicVolume = MainMenuManager.instance.playerData.musicVolume;
        MainMenuManager.instance.playerData.musicVolume = value;
       // MainMenuManager.instance.playerData.musicVolume = musicSlider.value;
        backgroundMusicSource.volume = value;
    }


    public void onSoundVolumeChanged(float value)
    {
        MainMenuManager.instance.playerData.soundVolume = value;
        foreach (AudioSource source in sfxSources)
        {
            source.volume = value;
        }
    }

    public void onMusicToggleChanged(bool toggleValue)
    {
        if (toggleValue)
        {
            backgroundMusicSource.mute = false;
            musicSlider.value = preMusicVolume;
        }
        else
        {
            backgroundMusicSource.mute = true;
            musicSlider.value = 0;
        }

        MainMenuManager.instance.playerData.isMusicOn = toggleValue;
    }

    public void onSoundToggleChanged(bool toggleValue)
    {
        if (toggleValue)
        {
            foreach (AudioSource source in sfxSources)
            {
                source.mute= false;
            }
        }
        else
        {
            foreach (AudioSource source in sfxSources)
            {
                source.mute = true;
            }
        }

        MainMenuManager.instance.playerData.isSoundOn = toggleValue;
    }
}