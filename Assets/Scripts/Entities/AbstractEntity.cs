using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEntity : MonoBehaviour, IDamagable
{
    [SerializeField] protected EntityData _entityData;

    protected EntityController _entityController;
    protected bool _isInit;

    public virtual void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        if (_isInit) return;

        _entityController = GetEntityController();

        EntityRegistry.RegisterEntity(this);

        _isInit = true;
    }    

    public abstract EntityController GetEntityController();

    public virtual void Damage(int damage)
    {
        if (!_isInit) Init();

        _entityController?.Damage(damage);
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isInit) Init();

        _entityController?.OnCollisionEnter2D(collision);
    }
}
