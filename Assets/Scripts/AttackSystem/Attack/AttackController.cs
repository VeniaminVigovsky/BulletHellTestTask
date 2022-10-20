using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : IAttackController
{
    private IInputProcessor _inputProcessor;
    private IAttackBehaviour _attackBehaviour;

    private bool _mainAttack;

    public void Attack()
    {
        if (_inputProcessor == null) return;

        if (_inputProcessor.GetFireAttack(_mainAttack))
        {
            _attackBehaviour?.Attack();
        }
    }
}
