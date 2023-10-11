using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioClip[] music;
    private AudioSource source;
    public float waitCountdown = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            if(waitCountdown <= 0)
            {
                source.clip = music[Random.Range(0, music.Length)];
                source.Play();
                waitCountdown = (float)Random.Range(5f, 10f);
            }
            else
            {
                waitCountdown -= Time.deltaTime;
            }
        }
        
    }
}
