using UnityEngine;
 
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
 
    [SerializeField]
    private SoundLibrary sfxLibrary;
    [SerializeField]
    private AudioSource sfx2DSource;
 
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
}