using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    public GameObject loadingBar;
    public Image loadingBarFill;
    public float HoldTime;

    private float timeHeld;
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            loadingBar.SetActive(true);
            timeHeld += Time.deltaTime;
            loadingBarFill.fillAmount = timeHeld/HoldTime;
            
            if(timeHeld > HoldTime)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            loadingBar.SetActive(false);
            timeHeld = 0;
        }
    }
}
