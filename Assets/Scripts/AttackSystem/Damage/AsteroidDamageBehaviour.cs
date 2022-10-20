using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamageBehaviour : IDamageBehaviour
{
    private IDamageBehaviour _damageBehaviour;

    public AsteroidDamageBehaviour(IDamageBehaviour damageBehaviour)
    {
        _damageBehaviour = damageBehaviour;
    }

    public void Damage(int damage)
    {
        var levelData = LevelManager.CurrentLevelData;
        if (levelData != null)
        {
            levelData.CurrentKillCount++;
        }
        _damageBehaviour?.Damage(damage);
    }
}
