using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDefault : MonoBehaviour
{
    public ObjectPoolDefault poolManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            poolManager.GetObjectFromPool();
        }
    }
}
