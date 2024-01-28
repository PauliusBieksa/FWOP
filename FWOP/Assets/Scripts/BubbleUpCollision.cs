using System;
using UnityEngine;


public class BubbleUpCollision : MonoBehaviour
{
    private PlayerSounds playersounds;
    void Start()
    {
        playersounds = GetComponentInParent<PlayerSounds>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        playersounds.ReceiveChildCollision(other);
    }
}



    