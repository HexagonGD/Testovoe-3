using UnityEngine;
using UnityEngine.UI;

namespace Testovoe3
{
    public class LevelInfoUI : MonoBehaviour
    {
        [SerializeField] private Image _backgroundLevel;
        [SerializeField] private Text _levelName;
        [SerializeField] private Button _startLevelButton;

        [SerializeField] private StarsUI _stars;
        [SerializeField] private StatisticUI _statisticUI;

        public void Show(Level level)
        {
            _backgroundLevel.sprite = level.LevelSettings.Background;
            gameObject.SetActive(true);
            _levelName.text = level.LevelSettings.Name;
            _stars.SetStars(level.LevelSettings.Difficult);
            _statisticUI.Show(level.LevelResult);

            _startLevelButton.onClick.AddListener(() =>
            {
                GameManager.Instance.LevelManager.StartLevel(level);
            });
        }

        public void Hide()
        {
            _startLevelButton.onClick.RemoveAllListeners();
            gameObject.SetActive(false);
        }
    }
}