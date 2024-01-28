using System;
using UnityEngine;


public class BubbleUpCollision : MonoBehaviour
{
    private BubbleUpCollision parent;
    private PlayerSounds playersounds;
    void Start()
    {
        parent = GetComponentInParent<BubbleUpCollision>();
        playersounds = GetComponent<PlayerSounds>();
    }

    public void BubbleUp(Collision2D other)
    {
        if (parent == null)
        {
            playersounds.RecieveChildCollison(other);
        }
        parent.BubbleUp(other);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        BubbleUp(other);
    }
}



    