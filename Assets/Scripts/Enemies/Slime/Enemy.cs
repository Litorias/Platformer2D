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
    private float _maxSqrDistance = 0.03f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _target = _wayPoints[_wayPointIndex].transform;
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

    private bool IsTargetReached()
    {
        float sqeDistance = (transform.position - _target.position).sqrMagnitude;

        return sqeDistance < _maxSqrDistance;
    }

    private void ChangeTarget()
    {
        _wayPointIndex = ++_wayPointIndex % _wayPoints.Length;
        _target = _wayPoints[_wayPointIndex].transform;

        if ((transform.position.x < _target.position.x && _isTurnRight == false)
            || (transform.position.x > _target.position.x && _isTurnRight))
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isTurnRight = !_isTurnRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
