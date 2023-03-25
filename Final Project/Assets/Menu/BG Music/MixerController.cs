using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudioMixer;

    // For the volume slider in the main menu
    public void SetVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
}
