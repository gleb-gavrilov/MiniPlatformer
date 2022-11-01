using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private const string RunAnimation = "IsRun";
    private const string JumpTrigger = "Jump";
    private const string GroundedAnimation = "IsGrounded";
    private const string Ground = "Ground";

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isRotate;
    private bool _isGround;
    private float _axisValue;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _axisValue = Input.GetAxis("Horizontal");
        _rigidBody.velocity = new Vector2(_axisValue * _speed, _rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        _isRotate = _axisValue < 0 ? true : false;
        _spriteRenderer.flipX = _isRotate;
        _animator.SetBool(RunAnimation, _axisValue != 0);
        _animator.SetBool(GroundedAnimation, _isGround);
    }

    private void Jump()
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _speed);
        _animator.SetTrigger(JumpTrigger);
        _isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground))
        {
            _isGround = true;
        }
    }
}
