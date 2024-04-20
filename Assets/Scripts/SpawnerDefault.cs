using System;
using UnityEngine;

public class SpawnerDefault : MonoBehaviour
{
    public static event Action<int> GameObjectID;

    public ObjectPoolDefault poolManager; // менеджер объектов пула
    public GameObject replacementPrefab; // префаб объекта, который будет создаваться
    private int _id;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем объект из пула
            GameObject obj = poolManager.GetObjectFromPool();
            _id++;
            GameObjectID?.Invoke(_id);
        }
    }
}
