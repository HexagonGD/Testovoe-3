using UnityEngine;
using UnityEngine.UI;

namespace Testovoe3
{
    public class LargeBonus : Bonus
    {
        public LargeBonus(ClickableObject clickable, Game game) : base(clickable, game)
        {
            _sprite = Resources.Load<Sprite>("LargeBonusSprite");
            Debug.Log(_sprite);
            _bonusIcon = GameObject.Find("LargeBonusIcon").GetComponent<Image>();
            _bonusIcon.color = Color.gray;
        }

        public override void Activate()
        {
            base.Activate();
            _clicable.transform.localScale = Vector3.one * 2f;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            _clicable.transform.localScale = Vector3.one;
        }

        protected override void OnClick()
        {
            _game.Click();
            _clicable.RefreshPosition();
        }
    }
}