using UnityEngine;

namespace Testovoe3
{
    public class EmptyBonus : IBonus
    {
        private readonly Game _game;
        private readonly ClickableObject _clickable;

        public EmptyBonus(ClickableObject clickable, Game game)
        {
            _game = game;
            _clickable = clickable;
        }

        public Sprite GetSprite() => null;

        public void Activate()
        {
            _clickable.ClickEvent += OnClick;
        }

        public void Deactivate()
        {
            _clickable.ClickEvent -= OnClick;
        }

        private void OnClick()
        {
            _game.Click();
            _clickable.RefreshPosition();
        }
    }
}