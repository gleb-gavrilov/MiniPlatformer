using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointsManager;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;

    private void Awake()
    {
        FillPoints();
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void FillPoints()
    {
        _points = new Transform[_pointsManager.childCount];

        for (int i = 0; i < _pointsManager.childCount; i++)
        {
            _points[i] = _pointsManager.GetChild(i);
        }
    }

}
