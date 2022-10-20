using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[CreateAssetMenu(fileName ="New EntityData", menuName ="GameData/EntityData")]
public class EntityData : ScriptableObject
{
    public ReactiveProperty<int> CurrentHealthCountRx 
    {
        get
        {
            if (_currentHealthCountRx == null)
            {
                _currentHealthCountRx = new ReactiveProperty<int>();
                _currentHealthCountRx.Value = _currentHealthCount;
            }

            return _currentHealthCountRx;
        }
    }
    public float MovementSpeed
    {
        get => _movementSpeed;
        set => _movementSpeed = value;
    }

    public float RotationSpeed
    {
        get => _rotationSpeed;
    }
    public int MaxHealthCount
    {
        get => _maxHealthCount;
    }
    public int CurrentHealthCount
    {
        get 
        {
            return CurrentHealthCountRx.Value;
        }
        set 
        {
            if (_currentHealthCount < 0) _currentHealthCount = 0;
            _currentHealthCount = value;
            CurrentHealthCountRx.Value = value;
        }
    }
    public float InvincibilityTime
    {
        get => _invincibilityTime;
    }

    public int ContactDamage
    {
        get => _contactDamage;
    }

    public LayerMask ContactDamageTargetLayerMask => _contactDamageTargetLayerMask;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private int _maxHealthCount;
    [SerializeField] private int _currentHealthCount;
    [SerializeField] private float _invincibilityTime;
    [SerializeField] private int _contactDamage;

    [SerializeField] private LayerMask _contactDamageTargetLayerMask;

    private ReactiveProperty<int> _currentHealthCountRx;
}
