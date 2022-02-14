using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Testovoe3
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private List<LevelSettings> _levelSettings;
        [SerializeField] private AudioClip _backgroundMusic;
        //Delete all level results
        [SerializeField] private bool _clearHistory;

        private void Start()
        {
            if (_clearHistory)
            {
                foreach (var settings in _levelSettings)
                {
                    LevelResultLoader.Clear(settings.Name);
                    PlayerPrefs.SetInt("Score", 0);
                }
            }

            GameManager.Instance.InitializeLevelManager(_levelSettings);
            AudioManager.Instance.PlayMusic(_backgroundMusic);

            SceneManager.LoadSceneAsync("Menu");
        }
    }
}