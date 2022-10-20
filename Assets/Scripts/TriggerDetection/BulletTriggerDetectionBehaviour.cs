using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggerDetectionBehaviour : ITriggerDetectionBehaviour
{
    private ITriggerDetectionBehaviour _triggerDetectionBehaviour;
    private LayerMask _collisionLayerMask;
    private GameObject _self;

    public BulletTriggerDetectionBehaviour(ITriggerDetectionBehaviour triggerDetectionBehaviour, LayerMask collisionLayerMask, GameObject self)
    {
        _triggerDetectionBehaviour = triggerDetectionBehaviour;
        _collisionLayerMask = collisionLayerMask;
        _self = self;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        int collisionLayer = collider.gameObject.layer;
        int collisionLayerMask = 1 << collisionLayer;
        if ((collisionLayerMask & _collisionLayerMask) != 0)
        {
            _triggerDetectionBehaviour?.OnTriggerEnter2D(collider);
            _self.SetActive(false);
        }
    }
}
