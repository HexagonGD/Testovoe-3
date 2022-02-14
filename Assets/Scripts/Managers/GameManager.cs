using System.Collections.Generic;

namespace Testovoe3
{
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }

        private LevelManager _levelManager;
        public LevelManager LevelManager => _levelManager;

        public void InitializeLevelManager(List<LevelSettings> levelSettings)
        {
            _levelManager = new LevelManager(levelSettings);
        }
    }
}