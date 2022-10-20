using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageCollisionDetectionBehaviour : ICollisionDetectionBehaviour
{    
    private LayerMask _contactDamageMask;
    private int _contactDamage;

    public ContactDamageCollisionDetectionBehaviour(LayerMask contactDamageMask, int contactDamage)
    {        
        _contactDamageMask = contactDamageMask;
        _contactDamage = contactDamage;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        int collisionLayerMask = 1 << collisionLayer;
        if ((collisionLayerMask & _contactDamageMask) != 0)
        {
            var damagable = collision.transform.GetComponent<IDamagable>();
            damagable?.Damage(_contactDamage);
        }        
    }
}
