using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPoolDefault : MonoBehaviour
{
    public ObjectPoolDefault[] pool; // пул объектов

    public GameObject prefab; // префаб объекта для пула
    public GameObject spawnPos; // позиция спавна
    public GameObject parent; // родительский объект (внутри него находятся все объекты из пула)

    public int poolSize = 10; // размер пула

    private List<GameObject> objectPool = new(); // лист объектов в пуле

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            DefaultLogic create = obj.GetComponent<DefaultLogic>();
            obj.transform.SetParent(parent.transform);
            create.poolManager = pool;
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }
    /* public void AddObjectToPool(GameObject obj)
    * {
    *     objectPool.Add(obj);
    * }
    */
    public GameObject GetObjectFromPool(Transform spawnPos)
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                obj.transform.position = spawnPos.transform.position;
                obj.GetComponent<Rigidbody>().isKinematic = false;
                return obj;
            }
        }

        // если все объекты из пула активны, создаём новый и добавляем в пул
        GameObject newObj = Instantiate(prefab);
        DefaultLogic create = newObj.GetComponent<DefaultLogic>();
        newObj.transform.position = spawnPos.transform.position;
        newObj.transform.SetParent(parent.transform);
        newObj.GetComponent<Rigidbody>().isKinematic = false;
        create.poolManager = pool;
        objectPool.Add(newObj);
        return newObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}