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

    private bool landed = false;

    public void ReceiveChildCollision(Collision2D other)
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
        
        if (other.gameObject.CompareTag("Pool") && !landed)
        {
            
            AudioSource.clip = Splashes[Random.Range(0, Splashes.Count-1)];
            AudioSource.Play();
            landed = true;
        }
        
        if (other.gameObject.CompareTag("Ground") && !landed)
        {
            AudioSource.clip = Splats[Random.Range(0, Splats.Count-1)];
            AudioSource.Play();
            landed = true;
        }
        
    }
}
