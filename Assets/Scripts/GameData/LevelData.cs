using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[Serializable]
public class LevelData
{
    public enum LevelStatus
    {
        Opened,
        Closed,
        Finished,
        Failed,
        Started,
        Unfinished        
    }

    public int LevelID => _levelID;

    public float AsteroidSpeed
    {
        get => _asteroidSpeed;
        set => _asteroidSpeed = value;
    }

    public float TimeBetweenSpawns
    {
        get => _timeBetweenSpawns;
        set => _timeBetweenSpawns = value;
    }

    public int TargetKillCount
    {
        get => _targetKillCount;
        set => _targetKillCount = value;
    }

    public int CurrentKillCount
    {
        get => CurrentKillCountRx.Value;
        set 
        {
            _currentKillCount = value;
            CurrentKillCountRx.Value = _currentKillCount;
        }
    }

    public LevelStatus CurrentLevelStatus
    {
        get => _currentLevelStatus;
        set 
        {
            _currentLevelStatus = value;
            CurrentLevelStatusRx.Value = _currentLevelStatus;
        } 
    }
    public int PlayerCurrentHealth
    {
        get => _playerCurrentHealth;
        set => _playerCurrentHealth = value;
    }

    public ReactiveProperty<int> CurrentKillCountRx
    {
        get
        {
            if (_currentKillCountRx == null)
            {
                _currentKillCountRx = new ReactiveProperty<int>(_currentKillCount);
            }

            return _currentKillCountRx;
        }
    }

    public ReactiveProperty<LevelStatus> CurrentLevelStatusRx
    {
        get
        {
            if (_currentLevelStatusRx == null)
            {
                _currentLevelStatusRx = new ReactiveProperty<LevelStatus>(_currentLevelStatus);
            }

            return _currentLevelStatusRx;
        }
    }

    [SerializeField] private int _levelID;
    [SerializeField] private float _asteroidSpeed = 250;
    [SerializeField] private float _timeBetweenSpawns = 1;
    [SerializeField] private int _targetKillCount = 10;
    [SerializeField] private int _currentKillCount = 0;
    [SerializeField] private LevelStatus _currentLevelStatus = LevelStatus.Closed;
    [SerializeField] private int _playerCurrentHealth;

    private ReactiveProperty<int> _currentKillCountRx;
    private ReactiveProperty<LevelStatus> _currentLevelStatusRx;

    public LevelData(int levelID, float asteroidSpeed, float timeBetweenSpawns, int targetKillCount, int currentKillCount, LevelStatus currentLevelStatus, int playerCurrentHealth)
    {
        _levelID = levelID;
        _asteroidSpeed = asteroidSpeed;
        _timeBetweenSpawns = timeBetweenSpawns;
        _targetKillCount = targetKillCount;
        _currentKillCount = currentKillCount;
        _currentLevelStatus = currentLevelStatus;
        _playerCurrentHealth = playerCurrentHealth;
    }
}
