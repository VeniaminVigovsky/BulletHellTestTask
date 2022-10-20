using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageTriggerDetectionBehaviour : ITriggerDetectionBehaviour
{
    private LayerMask _contactDamageMask;
    private int _contactDamage;

    public ContactDamageTriggerDetectionBehaviour(LayerMask contactDamageMask, int contactDamage)
    {
        _contactDamageMask = contactDamageMask;
        _contactDamage = contactDamage;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        int collisionLayer = collider.gameObject.layer;
        int collisionLayerMask = 1 << collisionLayer;
        if ((collisionLayerMask & _contactDamageMask) != 0)
        {
            var damagable = collider.transform.GetComponent<IDamagable>();
            damagable?.Damage(_contactDamage);
        }
    }

}
