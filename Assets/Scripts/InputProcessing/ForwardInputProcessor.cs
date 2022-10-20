using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardInputProcessor : IInputProcessor
{
    public Vector2 GetInputAxes()
    {
        return new Vector2(0.0f, 1.0f);
    }
}
