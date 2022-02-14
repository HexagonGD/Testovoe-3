using UnityEngine;

namespace Testovoe3
{
    [CreateAssetMenu(fileName = "Level Settings", menuName = "Testovoe/Level Settingss")]
    public class LevelSettings : ScriptableObject
    {
        [Header("Info")]
        [SerializeField] private string _name;
        [SerializeField] private int _scoreForOpen = 0;

        [Header("View")]
        [SerializeField] private Sprite _background;
        [SerializeField] private Sprite _item;

        [Header("Difficult")]
        [SerializeField, Min(1)] private int _seconds = 1;
        [SerializeField, Min(1)] private int _clickCountForWin = 1;
        [SerializeField, Range(1, 5)] private int _difficult = 1;

        public string Name => _name;
        public int ScoreForOpen => _scoreForOpen;
        public Sprite Background { get => _background; }
        public Sprite Item { get => _item; }
        public int Seconds { get => _seconds; }
        public int ClickCountForWin { get => _clickCountForWin; }
        public int Difficult { get => _difficult; }
    }
}