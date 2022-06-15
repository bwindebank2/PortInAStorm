using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    /// <summary>
    /// Sets the volume of the master channel.
    /// </summary>
    /// <param name="sliderValue"></param>
    public void SetMaster(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20); // takes 0.0001 slide value and convert to a number between -80 and 0 on logrithmic scale
    }
    /// <summary>
    /// Sets the volume of the music channel.
    /// </summary>
    /// <param name="sliderValue"></param>
    public void SetMusic(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    /// <summary>
    /// Sets the volume of the sfx channel.
    /// </summary>
    /// <param name="sliderValue"></param>
    public void SetSFX(float sliderValue)
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20); 
    }
    /// <summary>
    /// Sets the volume of the ambience channel.
    /// </summary>
    /// <param name="sliderValue"></param>
    public void SetAmbience(float sliderValue)
    {
        mixer.SetFloat("AmbienceVol", Mathf.Log10(sliderValue) * 20);
    }
}
