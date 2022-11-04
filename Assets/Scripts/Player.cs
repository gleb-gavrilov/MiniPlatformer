using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour 
{
    private const string DieAnimation = "IsDie";
    private float _health = 1;
    private Animator _animator;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damege)
    {
        _health -= damege;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
        _animator.SetTrigger(DieAnimation);
        SceneManager.LoadScene(0);
    }
}
