using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource myAudioSource;
    public static AudioSource instance;

    // Runs before Start()
    void Awake() {
        myAudioSource = GetComponent<AudioSource>();

        instance = myAudioSource;
    }

}
