using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputProcessor
{
    Vector2 GetInputAxes();
    bool GetFireAttack(bool main)
    {
        var name = main ? "Fire1" : "Fire2";
        return Input.GetButton(name);
    }
}
