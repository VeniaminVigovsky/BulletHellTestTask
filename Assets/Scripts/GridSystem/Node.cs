using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2 WorldPosition => _worldPosition;

    private int _x, _y;
    private Vector2 _worldPosition;

    public Node(int x, int y, Vector2 worldPosition)
    {
        _x = x;
        _y = y;
        _worldPosition = worldPosition;
    }
}
