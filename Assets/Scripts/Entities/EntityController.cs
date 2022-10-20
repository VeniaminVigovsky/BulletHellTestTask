using UnityEngine;

public class EntityController
{
    private MoveController _moveController; 
    private IDamageBehaviour _damageBehaviour;
    private ICollisionDetectionBehaviour _collisionDetectionBehaviour;    

    public EntityController(MoveController moveController, IDamageBehaviour damageBehaviour, ICollisionDetectionBehaviour collisionDetectionBehaviour)
    {
        _moveController = moveController;
        _damageBehaviour = damageBehaviour;
        _collisionDetectionBehaviour = collisionDetectionBehaviour;        
    }

    public void Move()
    {
        _moveController?.Move();
    }

    public void Damage(int damage)
    {
        _damageBehaviour?.Damage(damage);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        _collisionDetectionBehaviour?.OnCollisionEnter2D(collision);
    }

}
