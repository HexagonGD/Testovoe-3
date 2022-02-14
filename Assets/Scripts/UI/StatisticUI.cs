using UnityEngine;
using UnityEngine.UI;

namespace Testovoe3
{
    public class StatisticUI : MonoBehaviour
    {
        [SerializeField] private Text _bestTime;
        [SerializeField] private Text _wins;
        [SerializeField] private Text _attempts;

        private void Awake()
        {
            LayoutRebuilder.MarkLayoutForRebuild((RectTransform)transform);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        }

        public void Show(LevelResult levelResult)
        {
            _bestTime.text = levelResult.BestTime.ToString();
            _wins.text = levelResult.Wins.ToString();
            _attempts.text = levelResult.Attempts.ToString();
        }
    }
}