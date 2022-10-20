using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionPanel : MonoBehaviour
{
    [SerializeField] private LevelDataDB _levelDataDB;
    [SerializeField] private LevelDisplay _levelDisplayPrefab;

    private LevelSelectionPanelController _levelSelectionPanelController;

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        _levelSelectionPanelController = new LevelSelectionPanelController(_levelDisplayPrefab, transform, _levelDataDB);

        _isInit = true;
    }
}
