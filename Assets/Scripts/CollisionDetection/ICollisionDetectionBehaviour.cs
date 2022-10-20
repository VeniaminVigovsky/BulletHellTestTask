using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionDetectionBehaviour
{
    void OnCollisionEnter2D(Collision2D collision);
}
