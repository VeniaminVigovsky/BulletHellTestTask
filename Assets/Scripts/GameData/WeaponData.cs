using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : ScriptableObject
{
    public float CoolDownTime => _coolDownTime;
    public LayerMask TargetLayerMask => _targetLayerMask;

    public bool IsMainWeapon => _isMainWeapon;

    [SerializeField] protected LayerMask _targetLayerMask;
    [SerializeField] protected float _coolDownTime;
    [SerializeField] protected bool _isMainWeapon;
}
