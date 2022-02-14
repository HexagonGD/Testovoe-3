using UnityEngine;
using UnityEngine.UI;

namespace Testovoe3
{
    public class DoubleClickBonus : Bonus
    {
        public DoubleClickBonus(ClickableObject clickable, Game game) : base(clickable, game)
        {
            _sprite = Resources.Load<Sprite>("DoubleClickBonusSprite");
            Debug.Log(_sprite);
            _bonusIcon = GameObject.Find("DoubleClickBonusIcon").GetComponent<Image>();
            _bonusIcon.color = Color.gray;
        }

        protected override void OnClick()
        {
            _game.Click();
            _game.Click();
            _clicable.RefreshPosition();
        }
    }
}