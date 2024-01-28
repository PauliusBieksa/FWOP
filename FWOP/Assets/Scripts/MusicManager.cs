using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioSource MusicSource;
    public List<AudioClip> musicTracks;
    public static MusicManager Instance;

    private int attemptCount;
    
    void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneManager.sceneLoaded += StartNextTrack;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void StartNextTrack(Scene scene, LoadSceneMode mode)
    {
        //Skip 0,Increment on level load.
        //zero is the looping section.
        if (attemptCount < musicTracks.Count-1)
        {
            attemptCount++;
        }
        
        MusicSource.clip = musicTracks[attemptCount];
        MusicSource.Play();
        StartCoroutine(WaitForLoopSection());
    }

    IEnumerator WaitForLoopSection()
    {
        while (MusicSource.isPlaying)
        {
            yield return null;
        }
        
        MusicSource.clip = musicTracks[0];
        MusicSource.loop = true;
        MusicSource.Play();
        
    }
    
    
    
    
    
    
}
