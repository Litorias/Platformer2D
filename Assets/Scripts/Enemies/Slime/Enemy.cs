using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private WayPoint[] _wayPoints;
    [SerializeField] private float _speedX = 1;

    private Rigidbody2D _rigidbody;
    private bool _isTurnRight = true;
    private int _wayPointIndex;
    private Transform _target;
    private float _maxSqrDistance = 0.01f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();

        if (IsTargetReached())
            ChangeTarget();
    }

    private void Move()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, _target.position, _speedX * Time.fixedDeltaTime);
        _rigidbody.MovePosition(newPosition);
    }

    private void ChangeTarget()
    {
        float sqeDistance = (transform.position - _target.position).sqrMagnitude;

        return sqeDistance < _maxSqrDistance;
    }

    private bool IsTargetReached()
    {
        throw new NotImplementedException();
    }
}
