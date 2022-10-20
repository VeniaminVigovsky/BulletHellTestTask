using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInputProcessor : IInputProcessor
{
    public Vector2 GetInputAxes()
    {
        return Random.insideUnitCircle.normalized;
    }
}
