using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EntitySpawnerData", menuName = "GameData/SpawnerData/EntitySpawnerData")]
public class EntitySpawnerData : SpawnerData
{
    public AbstractEntity EntityPrefab => _entityPrefab;

    [SerializeField] private AbstractEntity _entityPrefab;
}
