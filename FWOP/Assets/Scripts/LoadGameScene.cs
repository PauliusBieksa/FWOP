using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    public string SceneName;
    
    public void LoadGameLevel()
    {
        SceneManager.LoadScene(SceneName);
    }
}
