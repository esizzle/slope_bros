using System.Collections;
using UnityEngine;
 
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
 
    [SerializeField]
    private SoundLibrary sfxLibrary;
    [SerializeField]
    private AudioSource sfx2DSource;
    [SerializeField]
    private AudioSource sfx2DSource2;
 
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
 
    public void PlaySound3D(AudioClip clip, Vector3 pos)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos);
        }
    }
 
    public void PlaySound3D(SoundID soundID, Vector3 pos)
    {
        PlaySound3D(sfxLibrary.GetClipFromID(soundID), pos);
    }
 
    public void PlaySound2D(SoundID soundID)
    {
        sfx2DSource.PlayOneShot(sfxLibrary.GetClipFromID(soundID));
    }

    public void PlaySled()
    {
        StartCoroutine(FadeIn(0.25f));
    }

    public void StopSled(){
        StartCoroutine(FadeOut(0.25f));
    }

    IEnumerator FadeOut(float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            sfx2DSource2.volume = Mathf.Lerp(1f, 0f, timer / duration);
            yield return null;
        }
    }

    IEnumerator FadeIn(float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            sfx2DSource2.volume = Mathf.Lerp(0f, 1f, timer / duration);
            yield return null;
        }
    }
}