using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ProjectileWeaponData", menuName = "GameData/WeaponData/ProjectileWeaponData")]
public class ProjectileWeaponData : WeaponData
{
    public Projectile ProjectilePrefab => _projectilePrefab;
    public float ProjectileSpeed => _projectileSpeed;
    public int ProjectileDamage => _projectileDamage;

    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private int _projectileDamage;
}
