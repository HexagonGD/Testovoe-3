using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Testovoe3
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private ClickableObject _clickableObj;
        [SerializeField] private SpriteRenderer _background;

        private Level _level;
        private Timer _timer;
        private int _clicks;

        public float LeftTime => _timer.LeftSeconds;

        public event Action<float> UpdateEvent;
        public event Action<int> ClicksChange;
        public UnityEvent StartGameEvent;
        public UnityEvent WinGameEvent;
        public UnityEvent LoseGameEvent;

        private void Start()
        {
            _level = GameManager.Instance.LevelManager.CurrentLevel;
            if (_level == null)
                throw new Exception("level has not been assigned");

            _clickableObj.SetSprite(_level.LevelSettings.Item);
            _background.sprite = _level.LevelSettings.Background;
            _timer = new Timer(ref UpdateEvent);
            StartGame();
        }

        private void Update()
        {
            UpdateEvent?.Invoke(Time.deltaTime);
        }

        public void StartGame()
        {
            _level.StartLevel();
            _timer.Start(_level.LevelSettings.Seconds);
            _timer.TimeEnd += Lose;
            _clicks = 0;

            StartGameEvent?.Invoke();
        }

        public void Click()
        {
            _clicks++;
            ClicksChange?.Invoke(_clicks);

            if (_clicks == _level.LevelSettings.ClickCountForWin)
            {
                Win();
            }
        }

        private void EndGame()
        {
            _timer.TimeEnd -= Lose;
            _timer.Pause();
            _clickableObj.gameObject.SetActive(false);
        }

        public void Win()
        {
            EndGame();
            _level.Win(Mathf.FloorToInt(_level.LevelSettings.Seconds - _timer.LeftSeconds));
            WinGameEvent?.Invoke();
            Debug.Log("WinGame");
        }

        public void Lose()
        {
            EndGame();
            LoseGameEvent?.Invoke();
            Debug.Log("LoseGame");
        }

        public void Restart()
        {
            SceneManager.LoadScene("Game");
        }
    }
}