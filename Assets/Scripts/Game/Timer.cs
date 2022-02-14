using System;

namespace Testovoe3
{
    public class Timer
    {
        private float _leftSeconds;
        private bool _isRunning = false;
        private bool _isPause = false;

        public float LeftSeconds => _leftSeconds;

        public event Action TimeEnd;

        public Timer(ref Action<float> Update)
        {
            Update += OnUpdate;
        }

        private void OnUpdate(float deltaTime)
        {
            if (_isRunning == false || _isPause) return;

            _leftSeconds -= deltaTime;
            if (_leftSeconds <= 0)
            {
                TimeEnd?.Invoke();
                _isRunning = false;
                _isPause = false;
            }
        }

        public void Start(float seconds)
        {
            _leftSeconds = seconds;
            _isRunning = true;
            _isPause = false;
        }

        public void Resume()
        {
            _isPause = false;
        }

        public void Pause()
        {
            _isPause = true;
        }
    }
}