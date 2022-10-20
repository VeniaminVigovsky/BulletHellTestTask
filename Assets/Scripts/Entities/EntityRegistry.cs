using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntityRegistry
{
    public static List<AbstractEntity> EntityList => _entityList;

    private static List<AbstractEntity> _entityList;

    public static void RegisterEntity(AbstractEntity entity)
    {
        if (_entityList == null) _entityList = new List<AbstractEntity>();
        if (_entityList.Contains(entity)) return;
        _entityList.Add(entity);
    }

    public static void ClearRegistry()
    {
        if (_entityList == null) return;
        foreach (var entity in _entityList)
        {
            if (entity == null) continue;
            Object.Destroy(entity.gameObject);
        }
        _entityList.Clear();
    }
}
