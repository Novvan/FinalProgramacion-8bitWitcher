using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Slider : MonoBehaviour
{
    public AudioMixer Mixer;

    public void setLevel(float slidervalue)
    {
        Mixer.SetFloat("MusicVolume",Mathf.Log10(slidervalue)*20);
    }
}
