using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Testovoe3
{
    public class LevelManager
    {
        private List<Level> _levels = new List<Level>();
        private Level _currentLevel;

        public IReadOnlyList<Level> Levels => _levels;
        public Level CurrentLevel => _currentLevel;

        public LevelManager(List<LevelSettings> levelsSettings)
        {
            foreach(var settings in levelsSettings)
                _levels.Add(new Level(settings));
        }

        public void StartLevel(Level level)
        {
            if(level.IsOpen == false)
            {
                //throw new System.Exception("Level " + level.LevelSettings.Name + " is lock.");
            }

            _currentLevel = level;
            SceneManager.LoadScene("Game");
        }
    }
}