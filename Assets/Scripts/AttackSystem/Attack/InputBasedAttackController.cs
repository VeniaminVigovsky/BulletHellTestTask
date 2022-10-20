using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBasedAttackController : IAttackController
{
    private IInputProcessor _inputProcessor;
    private IAttackBehaviour _attackBehaviour;

    private bool _isMainAttack;

    public InputBasedAttackController(IInputProcessor inputProcessor, IAttackBehaviour attackBehaviour, bool isMainAttack)
    {
        _inputProcessor = inputProcessor;
        _attackBehaviour = attackBehaviour;
        _isMainAttack = isMainAttack;
    }

    public void Attack()
    {
        if (_inputProcessor == null) return;

        if (_inputProcessor.GetFireAttack(_isMainAttack))
        {
            _attackBehaviour?.Attack();
        }
    }
}
