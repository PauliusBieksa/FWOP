using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ScoreReveal : MonoBehaviour
    {
        public List<Image> Scorecards;
        public AudioSource Drumroll;
        public float drumrollLength;
        public float scorePauseLength;
        public float finalHeight;
        public float startHeight;

        private void OnEnable()
        {
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
            Drumroll.Play();
            yield return new WaitForSeconds(drumrollLength);
            while (Scorecards[0].rectTransform.position.y < finalHeight)
            {
                float newY = Mathf.Lerp(startHeight, finalHeight, 0.5f);
                Scorecards[0].rectTransform.position = new Vector3(Scorecards[0].transform.position.x, newY, Scorecards[0].transform.position.z);
            }
        }
    }
    
}