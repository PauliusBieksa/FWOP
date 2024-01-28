using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCalculator : MonoBehaviour
{
    public static UnityAction<bool> OnDiveEnd;
    public float maxPossibleVelocity;
    public int maxScoreableSpins;
    
    
    [SerializeField] 
    private List<TextMeshProUGUI> scorecardTexts;

    [SerializeField] 
    private Rigidbody2D diverBody;
    
    public int spinCount = 0;
    private float currentAngle = 0;
    private float prevAngle = 0;
    private bool spinningClockwise;

    void Update()
    {
        currentAngle = diverBody.transform.rotation.eulerAngles.z;
        //If gone from 4th quadrant to 1st this frame then spinning clockwise
        if (prevAngle > 270 && currentAngle < 90)
        {
            if (spinningClockwise)
            {
                ++spinCount;
            }
            spinningClockwise = true;
        }
        //If gone from 1st to 4th quadrant this frame then spinning counterclockwise
        if (prevAngle < 90 && currentAngle > 270)
        {
            if (spinningClockwise)
            {
                ++spinCount;

            }
            spinningClockwise = false;
        }

        prevAngle = currentAngle;
    }

    //Debug Only
    public void ForceOnDiveEnd()
    {
        OnDiveEnd.Invoke(true);
    }
    
    void OnEnable()
    {
        OnDiveEnd += ScoreDive;
    }

    void ScoreDive(bool landedSafe)
    {
        int spinScore = 0;
        int speedScore = 0;
        int formScore = 0;
        
        if(landedSafe)
        {
            spinScore = GetSpinScore();
            speedScore = GetEntrySpeedScore(); 
            formScore = GetEntryAngleScore();
        }

        scorecardTexts[0].text = $"{spinScore}";
        scorecardTexts[1].text = $"{speedScore}";
        scorecardTexts[2].text = $"{formScore}";
    }

    int GetSpinScore()
    {
        var unboundSpinScore = Mathf.RoundToInt((spinCount / (float)maxScoreableSpins) * 10);
        return Mathf.Clamp(unboundSpinScore, 0, 10) ;
    }

    int GetEntrySpeedScore()
    {
        return Mathf.Clamp(Mathf.RoundToInt((diverBody.velocity.magnitude / maxPossibleVelocity) * 10), 0, 10);
    }

    int GetEntryAngleScore()
    {
        float verticality = Mathf.Abs(Vector3.Dot(Vector3.up, diverBody.transform.up));
        return Mathf.RoundToInt(verticality * 10);
    }

    private void OnDisable()
    {
        OnDiveEnd -= ScoreDive;
    }
}
