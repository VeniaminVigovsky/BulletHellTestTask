using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMoveBehaviour : IMoveBehaviour
{
    private Transform _selfT;
    private Rigidbody2D _rb;
    private float _movementSpeed;
    private float _rotationSpeed;

    public ForwardMoveBehaviour(Transform selfT, Rigidbody2D rb, float movementSpeed, float rotationSpeed)
    {
        _selfT = selfT;
        _rb = rb;
        _movementSpeed = movementSpeed;
        _rotationSpeed = rotationSpeed;
    }

    public void Move(Vector2 movementVector)
    {
        var x = movementVector.x;
        var y = movementVector.y;

        _rb.velocity = _selfT.up * y * _movementSpeed * Time.fixedDeltaTime;
        _selfT.Rotate(Vector3.back, _rotationSpeed * x * Time.fixedDeltaTime);
    }
}
