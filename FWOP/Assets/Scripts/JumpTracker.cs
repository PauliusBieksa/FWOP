using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTracker : MonoBehaviour
{
    [Range(0f,1f)]
    public float Progress = 0f;

    public Transform Top;
    private float TopY;
    public Transform Bottom;
    private float BottomY;
    
    // Start is called before the first frame update
    void Start()
    {
        TopY = Top.transform.position.y;
        BottomY = Bottom.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float currY = transform.position.y;
        Progress = Mathf.InverseLerp(TopY, BottomY, currY);
        SkyParallax.JumpCompletion = Progress;
    }
}
