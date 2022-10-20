using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _startButtonText;
    [SerializeField] private TMP_Text _levelStatusText;
    [SerializeField] private Button _button;

    private LevelDisplayController _levelDisplayController;
    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        _levelDisplayController = new LevelDisplayController(_startButtonText, _levelStatusText, _button);
        _isInit = true;
    }

    public void SetUpDisplay(LevelData levelData)
    {
        if (!_isInit) Init();

        _levelDisplayController?.SetUpDisplay(levelData);
    }

}
