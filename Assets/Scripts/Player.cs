using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour 
{
    private const string DieAnimation = "IsDie";
    private Animator _animator;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
        _animator.SetTrigger(DieAnimation);
    }
}
