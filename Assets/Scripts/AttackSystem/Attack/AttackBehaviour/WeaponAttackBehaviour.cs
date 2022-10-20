using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackBehaviour : IAttackBehaviour
{
    private WeaponController _weaponController;

    public WeaponAttackBehaviour(WeaponController weaponController)
    {
        _weaponController = weaponController;
    }

    public void Attack()
    {
        _weaponController?.UseWeapon();
    }
}
