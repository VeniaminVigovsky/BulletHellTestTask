using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GridController
{
    public HashSet<Node> Nodes => _nodes;

    private float _gridWidth, _gridHeight;
    private float _nodeSize;

    private int _nodeXCount, _nodeYCount;

    private Node[,] _nodeGrid;

    private HashSet<Node> _nodes;

    public GridController(float gridWidth, float gridHeight, float nodeSize, Vector2 bottomLeftCorner)
    {
        _gridWidth = gridWidth;
        _gridHeight = gridHeight;
        _nodeSize = nodeSize;

        CreateGrid(bottomLeftCorner);
    }

    private void CreateGrid(Vector2 bottomLeftCorner)
    {
        _nodeXCount = Mathf.RoundToInt(_gridWidth / _nodeSize);
        _nodeYCount = Mathf.RoundToInt(_gridHeight / _nodeSize);

        _nodeGrid = new Node[_nodeXCount, _nodeYCount];
        _nodes = new HashSet<Node>();

        bottomLeftCorner = new Vector2(bottomLeftCorner.x + _nodeSize * 0.5f, bottomLeftCorner.y + _nodeSize * 0.5f);

        for (int x = 0; x < _nodeXCount; x++)
        {
            for (int y = 0; y < _nodeYCount; y++)
            {
                var worldPositionX = bottomLeftCorner.x + x * _nodeSize;
                var worldPositionY = bottomLeftCorner.y + y * _nodeSize;
                var worldPosition = new Vector2(worldPositionX, worldPositionY);

                var node = new Node(x, y, worldPosition);
                _nodeGrid[x, y] = node;
                _nodes.Add(node);
            }
        }
    }

    public Node GetNode(Vector2 worldPosition)
    {
        if (_nodeGrid == null) return null;

        var minVector = _nodeGrid[0, 0].WorldPosition;
        var maxVector = _nodeGrid[_nodeXCount - 1, _nodeYCount - 1].WorldPosition;

        var xPercent = Mathf.InverseLerp(minVector.x, maxVector.x, worldPosition.x);
        var yPercent = Mathf.InverseLerp(minVector.y, maxVector.y, worldPosition.y);

        var x = Mathf.RoundToInt((_nodeXCount - 1) * xPercent);
        var y = Mathf.RoundToInt((_nodeYCount - 1) * yPercent);

        return _nodeGrid[x, y];
    }    
}
