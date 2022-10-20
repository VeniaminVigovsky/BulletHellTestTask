using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : AbstractEntity
{
    public override EntityController GetEntityController()
    {
        if (_entityController == null)
        {
            if (_entityData == null) return null;

            var rigidBody = GetComponent<Rigidbody2D>();
            var inputProcessor = new PlayerInputProcessor();
            var moveBehaviour = new ForwardMoveBehaviour(transform, rigidBody, _entityData.MovementSpeed, _entityData.RotationSpeed);

            var healthController = new HealthController(gameObject, _entityData);

            _entityController = new EntityController(
                moveController: new MoveController(inputProcessor, moveBehaviour),                
                damageBehaviour: new ReduceHealthDamageBehaviour(healthController),
                collisionDetectionBehaviour: new ContactDamageCollisionDetectionBehaviour(_entityData.ContactDamageTargetLayerMask, _entityData.ContactDamage)
                );
        }
        return _entityController;
    }

    private void FixedUpdate()
    {
        _entityController?.Move();
    }
}
