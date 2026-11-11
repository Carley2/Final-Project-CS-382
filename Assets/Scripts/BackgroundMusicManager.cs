using UnityEngine;
using System.Collections;

public class BackgroundMusicManager : MonoBehaviour
{
    private AudioSource musicSource;

    public float musicVolumeAfterDeath = 0f;
    public float fadeSpeed = 1f;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void LowerMusicVolume()
    {
        if (musicSource != null)
        {
            StartCoroutine(FadeMusic());
        }
    }

    IEnumerator FadeMusic()
    {
        while (musicSource.volume > musicVolumeAfterDeath)
        {
            musicSource.volume = Mathf.MoveTowards(
                musicSource.volume,
                musicVolumeAfterDeath,
                fadeSpeed * Time.unscaledDeltaTime
            );

            yield return null;
        }
    }
}

