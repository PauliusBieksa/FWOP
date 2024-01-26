using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreReveal : MonoBehaviour
{
    private UnityAction onDiveEnd;
    // Start is called before the first frame update
    void Enable()
    {
        onDiveEnd += ScoreDive;
    }

    // Update is called once per frame
    void ScoreDive()
    {
        
    }

    private void OnDisable()
    {
        onDiveEnd -= ScoreDive;
    }
}
