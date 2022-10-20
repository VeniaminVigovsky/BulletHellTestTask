using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EntitySpawnerData _spawnerData;
    [SerializeField] private EntityData _playerEntityData;

    private SpawnerController _spawnerController;
    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        if (_spawnerData == null)
        {
            _isInit = true;
            return;
        }

        _spawnerController = new SpawnerController(_spawnerData.EntityPrefab, _spawnerData.TimeBetweenSpawns, _playerEntityData);

        _isInit = true;
    }

    private void Update()
    {
        if (!_isInit) Init();

        _spawnerController?.Spawn();
    }

    private void OnDestroy()
    {
        if (!_isInit) Init();

        _spawnerController?.OnDestroy();
    }
}
