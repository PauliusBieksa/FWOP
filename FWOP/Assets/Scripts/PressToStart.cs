using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour
{
    float Delay = 1f;
    TextMeshProUGUI Text;
    Color OriginalTextColour;

    private bool TakingInput = false;

    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
        OriginalTextColour = Text.color;
        Text.color = new Color(0, 0, 0, 0);

        StartCoroutine(SceneOpenDelay());
    }

    IEnumerator SceneOpenDelay()
    {
        yield return new WaitForSeconds(Delay);
        TakingInput = true;
        StartCoroutine(FadeInText());
    }

    IEnumerator FadeInText()
    {
        float count = 0f;
        float fadeTime = 0.5f;
        while (count < fadeTime)
        {
            count += Time.deltaTime;
            Color fadeCol = OriginalTextColour;
            fadeCol.a = Mathf.Lerp(0f, 1f, count / fadeTime);
            Text.color = fadeCol;

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TakingInput && Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync("Instructions");
        }
    }
}
