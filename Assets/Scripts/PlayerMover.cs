using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody.velocity = new Vector2(1, 0);
    }
}
