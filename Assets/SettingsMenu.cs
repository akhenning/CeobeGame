using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void SetVolume(float volume) {
        //Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
         //float value;
        //Debug.Log(audioMixer.GetFloat("Volume",out value));
       // Debug.Log(value);
    }
}
