using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Testovoe3
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] private StatisticUI _statisticUI;
        [SerializeField] private Text _resultText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _menuButton.onClick.AddListener(OnMenuButtonClick);
        }

        public void ShowWinPanel()
        {
            _resultText.text = "SUCCESS";
            ShowPanel();
        }

        public void ShowLosePanel()
        {
            _resultText.text = "FAILED";
            ShowPanel();
        }

        private void ShowPanel()
        {
            _statisticUI.Show(GameManager.Instance.LevelManager.CurrentLevel.LevelResult);
            gameObject.SetActive(true);
        }

        private void OnRestartButtonClick()
        {
            SceneManager.LoadScene("Game");
        }

        private void OnMenuButtonClick()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}