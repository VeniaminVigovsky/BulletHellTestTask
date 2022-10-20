using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthBarText;
    [SerializeField] private EntityData _entityData;

    private HealthBarController _healthBarController;

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        _healthBarController = new HealthBarController(_entityData, _healthBarText);

        _isInit = true;
    }
}
