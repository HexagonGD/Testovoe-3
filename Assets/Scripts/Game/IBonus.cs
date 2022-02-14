using UnityEngine;

public interface IBonus
{
    Sprite GetSprite();
    void Activate();
    void Deactivate();
}