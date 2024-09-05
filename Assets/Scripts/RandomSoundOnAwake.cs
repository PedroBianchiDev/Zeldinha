using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundOnAwake : MonoBehaviour
{
    public List<AudioClip> audioClips;

    private AudioSource thisAudioSource;


    private void Awake()
    {
        thisAudioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        AudioClip audioClip = audioClips[Random.Range(0, audioClips.Count)];
        thisAudioSource.PlayOneShot(audioClip);
    }
}
