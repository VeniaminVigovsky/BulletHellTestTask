using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
public class HealthBarController
{
    private EntityData _entityData;
    private TMP_Text _healthBarText;

    public HealthBarController(EntityData entityData, TMP_Text healthBarText)
    {
        _entityData = entityData;
        _healthBarText = healthBarText;

        if (_entityData != null)
        {
            _entityData.CurrentHealthCountRx.Subscribe(UpdateText).AddTo(_healthBarText);
            UpdateText(_entityData.CurrentHealthCount);
        }        
    }

    private void UpdateText(int currentHealthCount)
    {
        if (_healthBarText == null) return;

        _healthBarText.text = $"Health: {currentHealthCount}";
    }

}
