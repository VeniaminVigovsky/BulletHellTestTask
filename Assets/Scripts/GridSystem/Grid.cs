using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid Instance
    {
        get
        {
            if (_instance == null)
            {
                var grid = FindObjectOfType<Grid>();
                grid?.Init();
            }

            return _instance;
        }

        set
        {
            if (_instance != null) return;

            _instance = value;
        }
    }

    [SerializeField] private Vector2 _gridSize = new Vector2(0.0f, 0.0f);


    [SerializeField][Min(1.0f)] private float _nodeSize = 1.0f;

    private static Grid _instance;

    private GridController _gridController;

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (_isInit) return;

        var gridWidth = _gridSize.x;        
        var gridHeight = _gridSize.y;
        var leftBottomCorner = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, -Camera.main.transform.position.z));
        
        _gridController = new GridController(gridWidth, gridHeight, _nodeSize, leftBottomCorner);

        Instance = this;
        _isInit = true;
    }

    public Node GetNode(Vector2 worldPosition)
    {
        if (!_isInit) Init();

        return _gridController?.GetNode(worldPosition);
    }

    public HashSet<Node> GetNodes()
    {
        if (!_isInit) Init();

        return _gridController?.Nodes;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (_gridSize != null)
        {
            Gizmos.DrawWireCube(Vector2.zero, _gridSize);
        }

        if (_gridController == null) return;

        var nodes = GetNodes();

        foreach (var node in nodes)
        {
            Gizmos.DrawWireCube(node.WorldPosition, Vector2.one * _nodeSize);
        }
    }
#endif

}
