using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource AudioSource;

    public List<AudioClip> Screams;
    public List<AudioClip> Splashes;
    public List<AudioClip> Splats;

    public void RecieveChildCollison(Collision2D other)
    {
        OnCollisionEnter2D(other);
    }
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (AudioSource.isPlaying)
        {
            return;
        }
        
        if (!AudioSource.isPlaying && other.gameObject.CompareTag("Obstacle"))
        {
            AudioSource.clip = Screams[Random.Range(0, Screams.Count-1)];
            AudioSource.Play();
        }
        
        if (other.gameObject.CompareTag("Pool"))
        {
            AudioSource.clip = Splashes[Random.Range(0, Splashes.Count-1)];
            AudioSource.Play();
        }
        
        if (other.gameObject.CompareTag("Ground"))
        {
            AudioSource.clip = Splats[Random.Range(0, Splats.Count-1)];
            AudioSource.Play();
        }
        
    }
}
