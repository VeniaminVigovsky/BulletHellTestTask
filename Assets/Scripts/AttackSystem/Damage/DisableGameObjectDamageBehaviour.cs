using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObjectDamageBehaviour : IDamageBehaviour
{
    private GameObject _self;

    public DisableGameObjectDamageBehaviour(GameObject self)
    {
        _self = self;
    }

    public void Damage(int damage)
    {
        if (_self == null) return;

        _self.SetActive(false);
    }
}
