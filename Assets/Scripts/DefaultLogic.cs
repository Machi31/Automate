using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLogic : MonoBehaviour
{
    public ObjectPoolDefault poolManager;
    
    public int id;
    public int collId;

    public GameObject replacementPrefab;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Предполагаем, что тег шара - "Ball"
        {
            // Создаем новый объект из префаба на месте текущего шара
            GameObject replacementObject = Instantiate(replacementPrefab, transform.position, Quaternion.identity);

            // Уничтожаем текущий шар
            Destroy(gameObject);

            // Уничтожаем шар, с которым произошло столкновение
            Destroy(collision.gameObject);
        }
    }
}
