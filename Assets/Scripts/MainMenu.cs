using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        LoadVolume();
        MusicManager.Instance.PlayMusic(MusicID.MainMenu);
    }

    public void Play()
    {
        LevelManager.Instance.LoadScene(SceneID.Game, TransitionID.CrossFade);
    }

    public void Menu() {
        LevelManager.Instance.LoadScene(SceneID.MainMenu, TransitionID.CircleWipe);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Linearize(volume));
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Linearize(volume));
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Linearize(volume));
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void LoadVolume()
    {
        masterSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("MasterVolume", 1f));
        musicSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("MusicVolume", 1f));
        sfxSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("SFXVolume", 1f));

        UpdateMasterVolume(masterSlider.value);
        UpdateMusicVolume(musicSlider.value);
        UpdateSoundVolume(sfxSlider.value);
    }

    private float Linearize(float volume) {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        return Mathf.Log10(volume) * 20f;
    }
}