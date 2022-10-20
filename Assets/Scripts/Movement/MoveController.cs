using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController
{
    private IInputProcessor _inputProcessor;
    private IMoveBehaviour _moveBehaviour;

    public MoveController(IInputProcessor inputProcessor, IMoveBehaviour moveBehaviour)
    {
        _inputProcessor = inputProcessor;
        _moveBehaviour = moveBehaviour;
    }

    public void Move()
    {
        if (_inputProcessor == null || _moveBehaviour == null) return;

        var movementVector = _inputProcessor.GetInputAxes();
        _moveBehaviour.Move(movementVector);
    }
}


