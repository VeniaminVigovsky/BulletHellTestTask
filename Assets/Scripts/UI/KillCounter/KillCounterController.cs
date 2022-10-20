using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class KillCounterController
{
    private LevelData _levelData;
    private TMP_Text _killCounterText;
    private int _targetKillCount;

    public KillCounterController(LevelData levelData, TMP_Text killCounterText)
    {
        _levelData = levelData;
        _killCounterText = killCounterText;

        if (_levelData != null)
        {
            _levelData.CurrentKillCountRx.Subscribe(UpdateText).AddTo(_killCounterText);
            _targetKillCount = _levelData.TargetKillCount;
            UpdateText(_levelData.CurrentKillCount);
        }
    }

    public void UpdateText(int killCount)
    {
        if (_killCounterText == null) return;

        _killCounterText.text = $"Killed: {killCount}/{_targetKillCount}";
    }
}
