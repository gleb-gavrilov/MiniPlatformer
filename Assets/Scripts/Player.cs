using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour 
{
    [SerializeField] private EventInt _coinsAdd;

    private const string DieAnimation = "IsDie";

    private int _coins;
    private float _health = 1;
    private Animator _animator;
    private Rigidbody2D _rigidBody;

    public void AddListener(UnityAction<int> action)
    {
        _coinsAdd.AddListener(action);
    }

    public void RemoveListener(UnityAction<int> action)
    {
        _coinsAdd.RemoveListener(action);
    }

    public void AddCoins(int value)
    {
        _coins += value;
        _coinsAdd.Invoke(_coins);
    }

    public void TakeDamage(float damege)
    {
        _health -= damege;

        if (_health <= 0)
        {
            Die();
        }
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Die()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
        _animator.SetTrigger(DieAnimation);
        SceneManager.LoadScene(0);
    }
}

[System.Serializable] public class EventInt : UnityEvent<int> { }
