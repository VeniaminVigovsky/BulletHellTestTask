using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponController WeaponController
    {
        get
        {
            return _weaponController;
        }
    }

    [SerializeField] private ProjectileWeaponData _weaponData;
    [SerializeField] private Transform _projectileSpawnPoint;

    private WeaponController _weaponController;
    private IAttackController _attackController;

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        if (_weaponData == null)
        {
            _isInit = true;
            return;
        }

        _weaponController = new WeaponController(_weaponData.ProjectilePrefab, transform, _projectileSpawnPoint, _weaponData.CoolDownTime, _weaponData.ProjectileSpeed, _weaponData.ProjectileDamage, _weaponData.TargetLayerMask);
        var inputProcessor = new PlayerInputProcessor();
        var attackBehaviour = new WeaponAttackBehaviour(_weaponController);

        _attackController = new InputBasedAttackController(inputProcessor, attackBehaviour, _weaponData.IsMainWeapon);
        _isInit = true;
    }

    private void Update()
    {
        if (!_isInit) Init();

        _attackController?.Attack();
    }

}
