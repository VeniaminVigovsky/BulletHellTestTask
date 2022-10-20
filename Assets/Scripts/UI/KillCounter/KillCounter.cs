using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _killCounterText;
    private KillCounterController _killCounterController;
    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        _killCounterController = new KillCounterController(LevelManager.CurrentLevelData, _killCounterText);

        _isInit = true;
    }

}
