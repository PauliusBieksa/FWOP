using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCalculator : MonoBehaviour
{
    public static UnityAction onDiveEnd;
    public float maxPossibleVelocity;
    public int maxScoreableSpins;
    
    
    [SerializeField] 
    private List<SpriteRenderer> scorecards;

    [SerializeField] 
    private Rigidbody2D diverBody;
    
    public int spinCount = 0;
    private float currentAngle = 0;
    private float prevAngle = 0;
    private bool spinningClockwise;

    void Update()
    {
        currentAngle = diverBody.transform.rotation.z;
        
        //If gone from 4th quadrant to 1st this frame then spinning clockwise
        if (prevAngle % 360 > 270 && currentAngle % 360 < 90)
        {
            if (spinningClockwise)
            {
                ++spinCount;
            }
            spinningClockwise = true;
        }
        //If gone from 1st to 4th quadrant this frame then spinning counterclockwise
        if (prevAngle % 360 < 90 && currentAngle % 360 > 270)
        {
            if (spinningClockwise)
            {
                ++spinCount;
            }
            spinningClockwise = false;
        }

        prevAngle = currentAngle;
    }
    
    void OnEnable()
    {
        onDiveEnd += ScoreDive;
    }

    void ScoreDive()
    {
        
    }

    int getSpinScore()
    {
        var unboundSpinScore = Mathf.RoundToInt((spinCount / maxScoreableSpins) * 10);
        return Mathf.Clamp(unboundSpinScore, 0, 10) ;
    }

    int getEntrySpeed()
    {
        return Mathf.RoundToInt((diverBody.velocity.magnitude / maxPossibleVelocity) * 10);
    }

    int getEntryAngle()
    {
        float verticality = Mathf.Abs(Vector3.Dot(Vector3.up, diverBody.transform.up));
        return Mathf.RoundToInt(verticality * 10);
    }

    private void OnDisable()
    {
        onDiveEnd -= ScoreDive;
    }
}
