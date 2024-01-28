using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        ScoreCalculator.OnDiveEnd.Invoke(false);
    }
}
