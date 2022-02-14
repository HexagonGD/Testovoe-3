using UnityEngine;
using UnityEngine.UI;

namespace Testovoe3
{
    public abstract class Bonus : IBonus
    {
        protected readonly ClickableObject _clicable;
        protected readonly Game _game;

        protected Sprite _sprite;
        protected Image _bonusIcon;

        public Bonus(ClickableObject clickable, Game game)
        {
            _clicable = clickable;
            _game = game;
        }

        public Sprite GetSprite() => _sprite;

        public virtual void Activate()
        {
            _clicable.ClickEvent += OnClick;
            _bonusIcon.color = Color.yellow;
        }

        public virtual void Deactivate()
        {
            _clicable.ClickEvent -= OnClick;
            _bonusIcon.color = Color.gray;
        }

        protected abstract void OnClick();
    }
}