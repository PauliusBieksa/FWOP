using System;
using UnityEngine;


public class BubbleUpCollision : MonoBehaviour
{
    private Collider2D parentCollider;
    void Start()
    {
        parentCollider = GetComponentInParent<Collider2D>();
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        parentCollider.O
    }
}



    