using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine.UI;

public class LevelDisplayController
{    
    private TMP_Text _startButtonText;
    private TMP_Text _levelStatusText;
    private Button _button;

    public LevelDisplayController(TMP_Text startButton, TMP_Text levelStatusText, Button button)
    {
        _startButtonText = startButton;
        _levelStatusText = levelStatusText;
        _button = button;
    }

    public void SetUpDisplay(LevelData levelData)
    {
        if (levelData == null || _startButtonText == null || _levelStatusText == null || _button == null) return;

        var status = levelData.CurrentLevelStatus;
        var levelId = levelData.LevelID;

        var statusText = "";
        switch (status)
        {
            case LevelData.LevelStatus.Opened:
                statusText = "OPENED";
                break;
            case LevelData.LevelStatus.Closed:
                statusText = "CLOSED";
                break;
            case LevelData.LevelStatus.Failed:
                statusText = "TRY AGAIN";
                break;
            case LevelData.LevelStatus.Unfinished:
                statusText = "UNFINISHED";
                break;
            case LevelData.LevelStatus.Finished:
                statusText = "FINISHED";
                break;
            default:
                statusText = "";
                break;
        }

        _levelStatusText.text = statusText;
        _startButtonText.text = $"Level {levelId}";

        if (levelData.CurrentLevelStatus != LevelData.LevelStatus.Closed)
        {
            _button.onClick.AsObservable().Subscribe((_) =>
            {
                if (levelData.CurrentLevelStatus == LevelData.LevelStatus.Opened || 
                    levelData.CurrentLevelStatus == LevelData.LevelStatus.Finished)
                {
                    levelData.CurrentLevelStatus = LevelData.LevelStatus.Started;
                }
                LevelManager.SetLevelData(levelData);
                _button.gameObject.SetActive(false);
            });
        }
        else
        {
            _button.enabled = false;
        }
    }    
}
