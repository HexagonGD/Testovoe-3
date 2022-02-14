using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsUI : MonoBehaviour
{
    [SerializeField] private List<Image> _stars;

    public void SetStars(int count)
    {
        for(var i = 0; i < count; i++)
            _stars[i].color = Color.white;
        for (var i = count; i < _stars.Count; i++)
            _stars[i].color = Color.black;
    }
}