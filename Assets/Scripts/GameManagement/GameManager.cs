using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelDataDB _levelDataDB;
    [SerializeField] private EntityData _playerEntityData;
    private GameManagerController _gameManagerController;
    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        var saveHandler = GetComponent<SaveHandler>();
        var sceneLoader = GetComponent<SceneLoader>();

        _gameManagerController = new GameManagerController(saveHandler, sceneLoader, _levelDataDB, gameObject, _playerEntityData);
        _isInit = true;
    }

    private void Start()
    {
        if (!_isInit) Init();

        _gameManagerController?.StartGame();

    }
}
