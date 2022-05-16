using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioClip[] musicClips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayRandomSong()
    {
       int temp = Random.Range(0, musicClips.Length); 
       GetComponent<AudioSource>().clip = musicClips[temp];
       GetComponent<AudioSource>().Play();
    }
}
