using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource sfxSource;
    public AudioSource bgmSource;

    void Awake()
    {
        if (instance == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            bgmSource = gameObject.AddComponent<AudioSource>();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySFX(string filePath)
    {
        AudioClip clip = Resources.Load<AudioClip>(filePath);
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"SFX file not found at: {filePath}");
        }
    }

    public void PlayBGM(string filePath)
    {
        AudioClip clip = Resources.Load<AudioClip>(filePath);
        if (clip != null)
        {
            bgmSource.clip = clip;
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning($"BGM file not found at: {filePath}");
        }
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }
}
