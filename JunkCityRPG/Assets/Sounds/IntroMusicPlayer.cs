using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusicPlayer : MonoBehaviour
{

    [SerializeField] private AudioClip introMusic;    

    public void StartIntroMusic() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = introMusic;
        audio.Play();
    }

}
