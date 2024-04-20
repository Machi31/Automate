using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDefault : MonoBehaviour
{
    public ObjectPoolDefault poolManager; // менеджер объектов пула
    public GameObject replacementPrefab; // префаб объекта, который будет создаваться

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем объект из пула
            GameObject obj = poolManager.GetObjectFromPool();
        }
    }
}
