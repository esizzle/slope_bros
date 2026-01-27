using System.Collections;
using UnityEngine;
 
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
 
    [SerializeField]
    private MusicLibrary musicLibrary;

    [SerializeField]
    private AudioSource musicSource;

    private MusicID currentSong;
 
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
 
    public void PlayMusic(MusicID musicID, float fadeDuration = 0.5f)
    {
        if (currentSong != musicID)
        {
            currentSong = musicID;
            StartCoroutine(AnimateMusicCrossfade(musicLibrary.GetClipFromID(musicID), fadeDuration));
        }
    }
 
    IEnumerator AnimateMusicCrossfade(AudioClip nextTrack, float fadeDuration)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0, percent);
            yield return null;
        }
 
        musicSource.clip = nextTrack;
        musicSource.Play();
 
        percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(0, 1f, percent);
            yield return null;
        }
    }
}