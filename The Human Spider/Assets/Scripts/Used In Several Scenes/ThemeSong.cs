using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ThemeSong : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] AudioSource mainTheme;

    [Header("Scene Number")]
    // Build Scene Index
    [SerializeField] int currentSceneIndex;

    private void Awake()
    {
        SetUpSingleton();
    }

    void Update()
    {
        FixedUpdate();
    }

    private void FixedUpdate()
    {
        // Grabs the number of the current scene
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if( currentSceneIndex == 2 ) 
        {
            // Fade out on loading screen
            StartCoroutine(FadeAudioSource.StartFade(mainTheme, 3f, 0));
        }

        // Destroy it on game screen
        if( currentSceneIndex == 3 ) 
        {
            Destroy(gameObject);
        }
    }

    private void SetUpSingleton()
    {
        // If there is already a music object for the main theme, do not start a new one
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PauseThemeSong()
    {
        mainTheme.Pause();
    }

    public void PlayThemeSong()
    {
        mainTheme.Play();
    }
    
}


/* Below is static class used to fade the audio source in/out */

public static class FadeAudioSource {

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
    
}