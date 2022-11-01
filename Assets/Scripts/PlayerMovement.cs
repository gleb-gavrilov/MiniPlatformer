using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private bool _isRotate;
    private float _axisValue;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _axisValue = Input.GetAxis("Horizontal");
        _rigidBody.velocity = new Vector2(_axisValue * _speed, _rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _speed);
        }

        _isRotate = _axisValue < 0 ? true : false;
        _spriteRenderer.flipX = _isRotate;
    }
}
