using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class ScoreReveal : MonoBehaviour
{
    public List<Image> Scorecards;
    public AudioSource DrumrollPLayer;
    public AudioClip drumrollClip;public AudioClip cymbolCrashClip;
    public float drumrollLength;
    public float scorePauseLength;
    public float finalHeight;
    public float startHeight;
    public GameObject hideableJudges;

    private void OnEnable()
    {
        DrumrollPLayer.clip = drumrollClip;
        startHeight = transform.position.y;
        ScoreCalculator.OnDiveEnd += RevealScores;
    }

    private void OnDisable()
    {
        ScoreCalculator.OnDiveEnd -= RevealScores;
    }

    void RevealScores()
    {
        StartCoroutine(RevealSequence());
    }

    IEnumerator RevealSequence()
    {
        hideableJudges.SetActive(true);
        DrumrollPLayer.Play();
        yield return new WaitForSeconds(drumrollClip.length);
        DrumrollPLayer.clip = cymbolCrashClip;

        foreach (var scorecard in Scorecards)
        {
            DrumrollPLayer.Play();
            float timeElapsed = 0f;
            while (scorecard.rectTransform.position.y < finalHeight)
            {
                yield return null;
                
                timeElapsed += Time.deltaTime;
                float newY = Mathf.Lerp(startHeight, finalHeight, timeElapsed / 0.5f);
                scorecard.rectTransform.position = new Vector3(scorecard.transform.position.x, newY, scorecard.transform.position.z);
            }
            yield return new WaitForSeconds(scorePauseLength);
        }
        
    }
}
    