using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private const string RunAnimation = "IsRun";
    private const string JumpOnAnimation = "JumpOn";
    private const string JumpOffAnimation = "JumpOff";

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isRotate;
    private bool _isGround;
    private float _axisValue;
    private float _groundRadius = 0.3f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isGround = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);
        _axisValue = Input.GetAxis("Horizontal");
        _rigidBody.velocity = new Vector2(_axisValue * _speed, _rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }

        _isRotate = _axisValue < 0;
        _spriteRenderer.flipX = _isRotate;
        _animator.SetBool(RunAnimation, _axisValue != 0);
    }

    private void Jump()
    {
        _animator.SetTrigger(JumpOnAnimation);
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
           _animator.SetTrigger(JumpOffAnimation);
        }
    }
}
