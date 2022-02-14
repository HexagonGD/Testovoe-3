using System.Collections;
using UnityEngine;

namespace Testovoe3
{
    public class LevelsMenu : MonoBehaviour
    {
        [SerializeField] private LevelInfoUI _levelInfoUI;
        [SerializeField] private LevelBox _levelBoxPrefab;
        [SerializeField] private Transform _content;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            StartCoroutine(InstantiateLevelBoxes());
        }

        private IEnumerator InstantiateLevelBoxes()
        {
            foreach (var level in GameManager.Instance.LevelManager.Levels)
            {
                var box = Instantiate(_levelBoxPrefab, _content, false);
                box.Initialize(level, _levelInfoUI);
                yield return null;
            }
        }
    }
}