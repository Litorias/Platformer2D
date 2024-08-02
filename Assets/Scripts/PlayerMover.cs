using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speedX = 0;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speedX * SPEED_COEFFICIENT * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }
}
