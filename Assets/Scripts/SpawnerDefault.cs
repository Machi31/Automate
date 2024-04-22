using System;
using UnityEngine;

public class SpawnerDefault : MonoBehaviour
{
    public ObjectPoolDefault[] poolManager; // менеджер объектов пула
    public Transform spawnPos;
    private int _id;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем объект из пула
            GameObject obj = poolManager[0].GetObjectFromPool(spawnPos);
            _id++;
            DefaultLogic defaultLogic = obj.GetComponent<DefaultLogic>();
            defaultLogic.id = _id;
        }
    }
}
