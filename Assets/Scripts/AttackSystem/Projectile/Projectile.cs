using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleLayerMask;
    private ProjectileController _projectileController;
    private bool _isInit;    

    public void Init(float speed, LayerMask enemyLayerMask, int damage)
    {
        if (_isInit) return;

        var rigidBody = GetComponent<Rigidbody2D>();
        var inputProcessor = new ForwardInputProcessor();
        var moveBehaviour = new ForwardMoveBehaviour(transform, rigidBody, speed, 0.0f);
        var contactDamageTriggerDetectionBehaviour = new ContactDamageTriggerDetectionBehaviour(enemyLayerMask, damage);

        _projectileController = new ProjectileController(
            moveController: new MoveController(inputProcessor, moveBehaviour),
            triggerDetectionBehaviour: new BulletTriggerDetectionBehaviour(contactDamageTriggerDetectionBehaviour, (enemyLayerMask | _obstacleLayerMask), gameObject)
            );

        _isInit = true;
    }

    public void Shoot()
    {
        _projectileController?.Move();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _projectileController?.OnTriggerEnter2D(collider);
    }
}
