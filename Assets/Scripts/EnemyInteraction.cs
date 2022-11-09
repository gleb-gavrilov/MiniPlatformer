using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyInteraction : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _damage = 100;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player _player)) {
            _spriteRenderer.color = Color.red;
            _player.TakeDamage(_damage);
        }
    }
}
