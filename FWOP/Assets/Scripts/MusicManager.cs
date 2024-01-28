using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource MusicSource;
    public List<AudioClip> musicTracks;
    public static MusicManager Instance;

    private float attemptCount;
    
    void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    ]

    void Start()
    {
        attemptCount++;
        
        MusicSource.Play();
    }
    
    
    
    
    
    
}
