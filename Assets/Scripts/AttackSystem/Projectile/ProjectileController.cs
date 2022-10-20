using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController
{
    private MoveController _moveController;
    private ITriggerDetectionBehaviour _triggerDetectionBehaviour;

    public ProjectileController(MoveController moveController, ITriggerDetectionBehaviour triggerDetectionBehaviour)
    {
        _moveController = moveController;
        _triggerDetectionBehaviour = triggerDetectionBehaviour;
    }

    public void Move()
    {
        _moveController?.Move();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        _triggerDetectionBehaviour?.OnTriggerEnter2D(collider);
    }
}
