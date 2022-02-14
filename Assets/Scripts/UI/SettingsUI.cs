using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup _group;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Button _settingsButton;

    private void Awake()
    {
        _musicToggle.isOn = AudioManager.Instance.MusicVolume > 0;
        _soundToggle.isOn = AudioManager.Instance.SoundVolume > 0;

        _musicToggle.onValueChanged.AddListener(OnMusicToggleChangedValue);
        _soundToggle.onValueChanged.AddListener(OnSoundToggleChangedValue);

        _group.alpha = 0;
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    private void OnMusicToggleChangedValue(bool value)
    {
        AudioManager.Instance.SetMusicVolume(value);
    }

    private void OnSoundToggleChangedValue(bool value)
    {
        AudioManager.Instance.SetSoundVolume(value);
    }

    private void OnDestroy()
    {
        _musicToggle.onValueChanged.RemoveListener(OnMusicToggleChangedValue);
        _soundToggle.onValueChanged.RemoveListener(OnSoundToggleChangedValue);
    }

    public void Show()
    {
        StopAllCoroutines();
        gameObject.SetActive(true);
        StartCoroutine(AlphaAnimationCoroutine(1f, true, 0.9f));
        _settingsButton.gameObject.SetActive(false);
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(AlphaAnimationCoroutine(0f, false, 0.9f));
        _settingsButton.gameObject.SetActive(true);
    }

    private IEnumerator AlphaAnimationCoroutine(float end, bool enable, float speed)
    {
        while(_group.alpha != end)
        {
            _group.alpha = Mathf.MoveTowards(_group.alpha, end, speed * Time.unscaledDeltaTime);
            yield return null;
        }
        gameObject.SetActive(enable);
    }
}