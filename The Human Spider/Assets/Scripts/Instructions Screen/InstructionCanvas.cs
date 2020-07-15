using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionCanvas : MonoBehaviour
{
    [Header("Times")]
    [SerializeField] float timeToShowQuote = 4.8f;

    [Header("Text Fields")]
    [SerializeField] TextMeshProUGUI FirstQuote;
    [SerializeField] TextMeshProUGUI SecondQuote;
    [SerializeField] TextMeshProUGUI ThirdQuote;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( ShowFirstQuote() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    IEnumerator ShowFirstQuote()
    {
        StartCoroutine( FadeTextToFullAlpha(1f, FirstQuote) );
        yield return new WaitForSeconds(timeToShowQuote);
        StartCoroutine( FadeTextToZeroAlpha(1f, FirstQuote) );

        // After showing first quote, show second
        StartCoroutine( ShowSecondQuote() );
    }

    IEnumerator ShowSecondQuote()
    {
        StartCoroutine( FadeTextToFullAlpha(1f, SecondQuote) );
        yield return new WaitForSeconds(timeToShowQuote);
        StartCoroutine( FadeTextToZeroAlpha(1f, SecondQuote) );

        // After showing second quote, show third
        StartCoroutine( ShowThirdQuote() );
    }

    IEnumerator ShowThirdQuote()
    {
        StartCoroutine( FadeTextToFullAlpha(1f, ThirdQuote) );
        yield return new WaitForSeconds(timeToShowQuote);
        StartCoroutine( FadeTextToZeroAlpha(1f, ThirdQuote) );
    }
}
