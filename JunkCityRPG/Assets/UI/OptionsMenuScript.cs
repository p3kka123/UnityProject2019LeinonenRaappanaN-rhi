using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenuScript : MonoBehaviour
{
    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

}
