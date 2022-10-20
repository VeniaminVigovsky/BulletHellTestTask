using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceHealthDamageBehaviour : IDamageBehaviour
{
    private HealthController _healthController;

    public ReduceHealthDamageBehaviour(HealthController healthController)
    {
        _healthController = healthController;
    }

    public void Damage(int damage)
    {
        _healthController?.ReduceHealth(damage);
    }
}
