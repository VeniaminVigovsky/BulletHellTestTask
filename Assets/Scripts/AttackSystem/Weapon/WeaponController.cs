using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController
{
    private ObjectPool<Projectile> _projectilePool;
    private Transform _projectileSpawnPoint;
    private Transform _selfT;
    private float _coolDownTime;
    private float _lastShotTime;

    private float _projectileSpeed;
    private int _projectileDamage;
    private LayerMask _enemyLayerMask;

    public WeaponController(Projectile projectilePrefab, Transform selfT, Transform projectileSpawnPoint, float coolDownTime, float projectileSpeed, int projectileDamage, LayerMask enemyLayerMask)
    {
        _projectilePool = new ObjectPool<Projectile>(projectilePrefab);
        _selfT = selfT;
        _projectileSpawnPoint = projectileSpawnPoint;
        _coolDownTime = coolDownTime;
        _lastShotTime = Time.time - _coolDownTime;
        _projectileSpeed = projectileSpeed;
        _projectileDamage = projectileDamage;
        _enemyLayerMask = enemyLayerMask;
    }

    public void UseWeapon()
    {
        if (_projectilePool == null || _lastShotTime + _coolDownTime > Time.time) return;

        var projectile = _projectilePool.GetFromPool();
        if (projectile == null) return;

        var projectileTransform = projectile.transform;
        projectileTransform.position = _selfT.position;
        projectileTransform.rotation = _selfT.rotation;

        projectile.Init(_projectileSpeed, _enemyLayerMask, _projectileDamage);
        projectile.Shoot();
        _lastShotTime = Time.time;
    }
}
