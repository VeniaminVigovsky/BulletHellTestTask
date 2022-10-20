using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController
{
    private ObjectPool<AbstractEntity> _entityPool;
    private float _timeBetweenSpawns;
    private float _spawnTime;

    private Grid _grid;
    private HashSet<Node> _nodes;

    private EntityData _playerEntityData;

    public SpawnerController(AbstractEntity entityToSpawn, float timeBetweenSpawns, EntityData playerEntityData)
    {
        _entityPool = new ObjectPool<AbstractEntity>(entityToSpawn);
        _timeBetweenSpawns = timeBetweenSpawns;
        _spawnTime = Time.time - _timeBetweenSpawns;

        _grid = Grid.Instance;
        if (_grid != null)
        {
            _nodes = _grid.GetNodes();
        }
        _playerEntityData = playerEntityData;
    }

    public void Spawn()
    {
        if (_entityPool == null || _spawnTime + _timeBetweenSpawns > Time.time
            || _playerEntityData == null || _playerEntityData.CurrentHealthCount <= 0) return;

        var entity = _entityPool.GetFromPool();
        entity.transform.position = GetPosition();
        _spawnTime = Time.time;
    }

    public void OnDestroy()
    {
        EntityRegistry.ClearRegistry();
    }

    private Vector2 GetPosition()
    {
        if (_grid == null || _nodes == null) return GetRandomPosition();

        var entities = EntityRegistry.EntityList;

        if (entities == null) return GetRandomPosition();

        var occupiedPositions = new List<Vector2>();

        foreach (var entity in entities)
        {
            if (entity.gameObject.activeInHierarchy)
            {
                occupiedPositions.Add(entity.transform.position);
            }
        }

        var occupiedNodes = new HashSet<Node>();

        foreach (var occupiedPosition in occupiedPositions)
        {
            var node = _grid.GetNode(occupiedPosition);           
            occupiedNodes.Add(node);
        }

        var nodes = new HashSet<Node>(_nodes);

        nodes.ExceptWith(occupiedNodes);

        var nodeList = new List<Node>(nodes);

        var count = nodeList.Count;

        var r = Random.Range(0, count);

        return nodeList[r].WorldPosition;

    }

    private Vector2 GetRandomPosition()
    {
        return Random.insideUnitCircle * 5.0f;
    }
}
