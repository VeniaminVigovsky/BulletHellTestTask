using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{    
    [SerializeField] private GameObject _endScreenPanel;
    [SerializeField] private TMP_Text _endScreenText;

    private EndScreenController _endScreenController;

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        _endScreenController = new EndScreenController(_endScreenPanel, _endScreenText, this);

        _isInit = true;
    }
}
