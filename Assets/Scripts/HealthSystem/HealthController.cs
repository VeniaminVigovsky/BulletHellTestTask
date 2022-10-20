using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : IHealthController
{
    private GameObject _self;
    EntityData _entityData;

    private float _invincibleTime;
    private float _lastHitTime;

    public HealthController(GameObject self, EntityData entityData)
    {
        _self = self;
        _entityData = entityData;
        if (_entityData != null)
        {
            _invincibleTime = _entityData.InvincibilityTime;
        }
        
        _lastHitTime = Time.time;
    }

    public void ReduceHealth(int damage)
    {
        if (_lastHitTime + _invincibleTime > Time.time || _entityData == null) return;
        
        _entityData.CurrentHealthCount -= damage;
        _lastHitTime = Time.time;
        
        if (_entityData.CurrentHealthCount <= 0)
        {
            _self.SetActive(false);
        }
    }
}
