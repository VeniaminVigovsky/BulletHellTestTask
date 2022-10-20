using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerData : ScriptableObject
{
    public float TimeBetweenSpawns
    {
        get => _timeBetweenSpawns;
        set => _timeBetweenSpawns = value;
    }

    [SerializeField] protected float _timeBetweenSpawns;    
}
