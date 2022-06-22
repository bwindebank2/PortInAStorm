using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    private void Awake()
    {
        LoadVolumeLevels();
    }
    void LoadVolumeLevels()
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(PlayerPrefs.GetFloat("MasterVol")));
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVol")));
        mixer.SetFloat("SFXVol", Mathf.Log10(PlayerPrefs.GetFloat("SFXVol")));
        mixer.SetFloat("AmbienceVol", Mathf.Log10(PlayerPrefs.GetFloat("AmbienceVol")));
    }

    void SaveVolume(string stringname, float sliderValue)
    {
        PlayerPrefs.SetFloat(stringname, sliderValue);
    }

    /// <summary>
    /// Sets the volume of the master channel.
    /// </summary>
    /// <param name="sliderValue"></param>
    public void SetMaster(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20); // takes 0.0001 slide value and convert to a number between -80 and 0 on logrithmic scale
        SaveVolume("MasterVol", sliderValue);
    }
    /// <summary>
    /// Sets the volume of the music channel.
    /// </summary>
    /// <param name="sliderValue"></param>
    public void SetMusic(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        SaveVolume("MusicVol", sliderValue);
    }
    /// <summary>
    /// Sets the volume of the sfx channel.
    /// </summary>
    /// <param name="sliderValue"></param>
    public void SetSFX(float sliderValue)
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        SaveVolume("SFXVol", sliderValue);
    }
    /// <summary>
    /// Sets the volume of the ambience channel.
    /// </summary>
    /// <param name="sliderValue"></param>
    public void SetAmbience(float sliderValue)
    {
        mixer.SetFloat("AmbienceVol", Mathf.Log10(sliderValue) * 20);
        SaveVolume("AmbienceVol", sliderValue);
    }
}
