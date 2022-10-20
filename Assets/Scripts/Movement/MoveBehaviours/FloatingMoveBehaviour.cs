using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMoveBehaviour : IMoveBehaviour
{
    private Rigidbody2D _rb;
    private float _movementSpeed;

    public FloatingMoveBehaviour(Rigidbody2D rb, float movementSpeed)
    {
        _rb = rb;
        _movementSpeed = movementSpeed;
    }

    public void Move(Vector2 movementVector)
    {
        if (_rb == null) return;

        _rb.velocity = movementVector * _movementSpeed * Time.fixedDeltaTime;
    }
}
