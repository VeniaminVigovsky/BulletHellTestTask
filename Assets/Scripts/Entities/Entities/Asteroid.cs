using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : AbstractEntity
{
    public override EntityController GetEntityController()
    {
        if (_entityController == null)
        {
            if (_entityData == null) return null;

            var rigidBody = GetComponent<Rigidbody2D>();
            var inputProcessor = new RandomInputProcessor();
            var moveBehaviour = new FloatingMoveBehaviour(rigidBody, _entityData.MovementSpeed);

            _entityController = new EntityController(
                moveController: new MoveController(inputProcessor, moveBehaviour),                
                damageBehaviour: new AsteroidDamageBehaviour(new DisableGameObjectDamageBehaviour(gameObject)),
                collisionDetectionBehaviour: new ContactDamageCollisionDetectionBehaviour(_entityData.ContactDamageTargetLayerMask, _entityData.ContactDamage)
                );
        }

        return _entityController;
    }

    private void OnEnable()
    {
        if (!_isInit) Init();

        _entityController?.Move();
    }
}
