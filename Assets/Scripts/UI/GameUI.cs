using UnityEngine;
using UnityEngine.UI;

namespace Testovoe3
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private Slider _goalSlider;
        [SerializeField] private Text _timerText;
        [SerializeField] private Text _countClickForWinText;
        [SerializeField] private Text _currentClicksText;

        private Level _level;

        public void Start()
        {
            _game.ClicksChange += OnClicksChange;
            _level = GameManager.Instance.LevelManager.CurrentLevel;
            _goalSlider.value = 0;
            _timerText.text = _level.LevelSettings.Seconds.ToString();
            _countClickForWinText.text = _level.LevelSettings.ClickCountForWin.ToString();
            _currentClicksText.text = "0/" + _level.LevelSettings.ClickCountForWin.ToString();
        }

        private void Update()
        {
            _timerText.text = _game.LeftTime.ToString("00");
        }

        private void OnClicksChange(int clicks)
        {
            _goalSlider.value = (float)clicks / _level.LevelSettings.ClickCountForWin;
            _currentClicksText.text = clicks.ToString() + "/" + _level.LevelSettings.ClickCountForWin;
        }
    }
}