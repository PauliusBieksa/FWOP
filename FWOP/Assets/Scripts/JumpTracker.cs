using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTracker : MonoBehaviour
{
    [Range(0f,1f)]
    public float Progress = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SkyParallax.JumpCompletion = Progress;
    }
}
