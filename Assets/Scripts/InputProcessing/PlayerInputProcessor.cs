using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputProcessor : IInputProcessor
{
    public Vector2 GetInputAxes()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
