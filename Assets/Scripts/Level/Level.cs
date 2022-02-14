using UnityEngine;

namespace Testovoe3
{
    public class Level
    {
        public readonly LevelSettings LevelSettings;

        private LevelResult _levelResult;

        public LevelResult LevelResult => _levelResult;
        public bool IsOpen => PlayerPrefs.GetInt("Score", 0) >= LevelSettings.ScoreForOpen;

        public Level(LevelSettings levelSettings)
        {
            LevelSettings = levelSettings;

            if (LevelResultLoader.TryLoad(LevelSettings.Name, out var levelResult))
            {
                _levelResult = levelResult;
            }
        }

        public void StartLevel()
        {
            _levelResult.Attempts++;
            Save();
        }

        public void Win(int seconds)
        {
            var score = PlayerPrefs.GetInt("Score", 0);
            score = Mathf.Max(score, LevelSettings.ScoreForOpen + 1);
            PlayerPrefs.SetInt("Score", score);

            if (_levelResult.BestTime > 0)
                _levelResult.BestTime = Mathf.Min(_levelResult.BestTime, seconds);
            else
                _levelResult.BestTime = seconds;
            _levelResult.Wins++;
            Save();
        }

        private void Save()
        {
            LevelResultSaver.Save(LevelSettings.Name, _levelResult);
        }
    }
}