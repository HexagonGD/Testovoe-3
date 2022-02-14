using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ClickableObject : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private BoxCollider2D _collider;
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioClip _clickSound;

    public event Action ClickEvent;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        RefreshCollider();
    }

    public void SetSprite(Sprite sprite)
    {
        _renderer.sprite = sprite;
        RefreshCollider();
    }

    public void RefreshCollider()
    {
        _collider.size = _renderer.sprite.bounds.size;
        _collider.offset = Vector2.zero;
    }

    public void RefreshPosition()
    {
        var aspect = (float)Screen.width / Screen.height;
        var height = _camera.orthographicSize;
        var width = height * aspect - _renderer.sprite.bounds.size.x / 2f;
        height -= _renderer.sprite.bounds.size.y / 2f;

        var x = UnityEngine.Random.Range(-width, width * 0.5f);
        var y = UnityEngine.Random.Range(-height, height * 0.5f);

        transform.position = new Vector3(x, y, 0);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        ClickEvent?.Invoke();
        if(_clickSound != null)
        {
            AudioManager.Instance.PlaySound(_clickSound);
        }
    }
}