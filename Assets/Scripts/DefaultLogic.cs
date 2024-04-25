using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLogic : MonoBehaviour
{
    public ObjectPoolDefault[] poolManager;
    
    public int id;
    public int collId;

    public GameObject replacementPrefab; // Это будет использоваться для замены первого шара
    public GameObject biggerReplacementPrefab; // Это будет использоваться для замены второго шара

    // Поле для хранения позиции спавна
    public GameObject spawnPos;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && 
        collision.gameObject.GetComponent<DefaultLogic>().collId == collId)
        {
            // Получаем компонент DefaultLogic другого шара
            DefaultLogic otherBallLogic = collision.gameObject.GetComponent<DefaultLogic>();

            // Если ID текущего шара меньше ID другого шара, то удаляем текущий шар
            if (id < otherBallLogic.id)
            {
                // Получаем позицию столкновения
                Transform collisionTransform = collision.contacts[0].otherCollider.transform;

                // Создаем новый объект из префаба на месте столкновения, немного выше
                GameObject replacementObject = poolManager[collId + 1].GetObjectFromPool(collisionTransform);


                // Устанавливаем новый ID для нового шара
                DefaultLogic newBallLogic = replacementObject.GetComponent<DefaultLogic>();
                newBallLogic.id = id + 1;

                // Уничтожаем текущий шар
                poolManager[collId].ReturnObjectToPool(gameObject);
            }
            else
            {
                // Если ID текущего шара больше или равен ID другого шара, то удаляем другой шар
                poolManager[collId].ReturnObjectToPool(gameObject);
            }
        }
    }
}