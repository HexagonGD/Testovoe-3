using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Testovoe3
{
    public class BonusManager : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private ClickableObject _clickable;

        [SerializeField] private ClickableObject _bonusClickable;

        private List<IBonus> _bonuses = new List<IBonus>();
        private IBonus _currentBonus;
        private IBonus _nextBonus;

        private void Awake()
        {
            _bonusClickable.ClickEvent += ActivateBonus;

            _currentBonus = new EmptyBonus(_clickable, _game);
            _currentBonus.Activate();

            _bonuses.Add(new LargeBonus(_clickable, _game));
            _bonuses.Add(new DoubleClickBonus(_clickable, _game));
            _bonuses.Add(new StopBonus(_clickable, _game));
        }

        private void ActivateBonus()
        {
            _bonusClickable.gameObject.SetActive(false);
            _currentBonus.Deactivate();
            _currentBonus = _nextBonus;
            _currentBonus.Activate();
            _nextBonus = null;
            StartCoroutine(DeactivateBonusCoroutine());
        }

        private void DeactivateBonus()
        {
            _currentBonus.Deactivate();
            _currentBonus = new EmptyBonus(_clickable, _game);
        }

        private IEnumerator DeactivateBonusCoroutine()
        {
            yield return new WaitForSeconds(5f);
            DeactivateBonus();
        }

        private IEnumerator GenerateBonusCoroutine()
        {
            Debug.Log("Generate");
            yield return new WaitForSeconds(Random.Range(5, 10));
            var index = Random.Range(0, _bonuses.Count);
            var bonus = _bonuses[index];

            Debug.Log(bonus.GetSprite());
            _bonusClickable.SetSprite(bonus.GetSprite());
            _bonusClickable.gameObject.SetActive(true);
            _bonusClickable.RefreshPosition();
            _nextBonus = bonus;
        }

        public void StartGame()
        {
            Debug.Log("OnStartGame");
            Reset();
            _currentBonus.Activate();
            StartCoroutine(GenerateBonusCoroutine());
        }

        public void EndGame()
        {
            Reset();
        }

        private void Reset()
        {
            StopAllCoroutines();
            _currentBonus.Deactivate();
            _currentBonus = new EmptyBonus(_clickable, _game);
            _bonusClickable.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _bonusClickable.ClickEvent -= ActivateBonus;
        }
    }
}