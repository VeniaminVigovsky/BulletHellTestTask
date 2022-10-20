using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerDetectionBehaviour
{
    void OnTriggerEnter2D(Collider2D collider);
}
