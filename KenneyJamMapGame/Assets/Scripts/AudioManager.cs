using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] pencilSounds;
    public AudioClip[] paperSounds;
    public AudioClip victory;
    public AudioClip failure;

    private AudioSource source;

    private void Awake()
    {
        if(instance == null){
            instance = this;
        }else if(AudioManager.instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    public void PlayPencilSound()
    {
        source.clip = pencilSounds[Random.Range(0, pencilSounds.Length)];
        source.Play();
    }

    public void PlayPaperSound()
    {
        source.clip = paperSounds[Random.Range(0, paperSounds.Length)];
        source.Play();
    }

    public void Victory()
    {
        source.clip = victory;
        source.Play();
    }

    public void Failure()
    {
        source.clip = failure;
        source.Play();
    }
}
