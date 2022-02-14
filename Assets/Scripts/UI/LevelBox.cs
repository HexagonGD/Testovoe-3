using UnityEngine;
using UnityEngine.UI;

namespace Testovoe3
{
    [RequireComponent(typeof(Button))]
    public class LevelBox : MonoBehaviour
    {
        [SerializeField] private StarsUI _starsUI;
        [SerializeField] private Image _background;
        [SerializeField] private Image _lock;
        [SerializeField] private Text _name;
        private Level _level;
        private LevelInfoUI _levelInfoUI;

        public void Initialize(Level level, LevelInfoUI levelInfoUI)
        {
            if (level.IsOpen)
            {
                _level = level;
                _levelInfoUI = levelInfoUI;
                _starsUI.SetStars(level.LevelSettings.Difficult);
                _background.sprite = level.LevelSettings.Background;
                _name.text = level.LevelSettings.Name;
                GetComponent<Button>().onClick.AddListener(ShowInfo);
            }
            else
            {
                _lock.gameObject.SetActive(true);
            }
        }

        public void ShowInfo()
        {
            _levelInfoUI.Show(_level);
        }
    }
}