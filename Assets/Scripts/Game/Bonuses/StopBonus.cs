using UnityEngine;
using UnityEngine.UI;

namespace Testovoe3
{
    public class StopBonus : Bonus
    {
        public StopBonus(ClickableObject clickable, Game game) : base(clickable, game)
        {
            _sprite = Resources.Load<Sprite>("StopBonusSprite");
            Debug.Log(_sprite);
            _bonusIcon = GameObject.Find("StopBonusIcon").GetComponent<Image>();
            _bonusIcon.color = Color.gray;
        }

        protected override void OnClick()
        {
            _game.Click();
        }
    }
}