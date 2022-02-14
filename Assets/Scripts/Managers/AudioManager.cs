using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                var instance = new GameObject("AudioManager");
                _instance = instance.AddComponent<AudioManager>();
                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }

    private AudioSource _music;
    private AudioSource _sound;

    public float MusicVolume => _music.volume;
    public float SoundVolume => _sound.volume;

    private void Awake()
    {
        _music = gameObject.AddComponent<AudioSource>();
        _sound = gameObject.AddComponent<AudioSource>();

        _music.loop = true;

        _music.volume = PlayerPrefs.GetInt("MusicVolume", 1);
        _sound.volume = PlayerPrefs.GetInt("SoundVolume", 1);
    }

    public void SetMusicVolume(bool value)
    {
        _music.volume = value ? 1 : 0;
        PlayerPrefs.SetInt("MusicVolume", value ? 1 : 0);
    }
    
    public void SetSoundVolume(bool value)
    {
        _sound.volume = value ? 1 : 0;
        PlayerPrefs.SetInt("SoundVolume", value ? 1 : 0);
    }

    public void PlayMusic(AudioClip clip)
    {
        _music.clip = clip;
        _music.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        _sound.clip = clip;
        _sound.Play();
    }
}