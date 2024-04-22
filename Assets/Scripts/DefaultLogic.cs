using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLogic : MonoBehaviour
{
    public ObjectPoolDefault poolManager;
    
    public int id;
    public int collId;

    public GameObject replacementPrefab; // Это будет использоваться для замены первого шара
    public GameObject biggerReplacementPrefab; // Это будет использоваться для замены второго шара

    // Поле для хранения позиции спавна
    public GameObject spawnPos;

    private void Start() {
        SpawnerDefault.GameObjectID += SetId;
    }

    private void SetId(int id) {
        this.id = id;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Предполагаем, что тег шара - "Ball"
        {
            // Получаем компонент DefaultLogic другого шара
            DefaultLogic otherBallLogic = collision.gameObject.GetComponent<DefaultLogic>();

            // Если ID текущего шара меньше ID другого шара, то удаляем текущий шар
            if (id < otherBallLogic.id)
            {
                // Получаем позицию столкновения
                Vector3 collisionPoint = collision.contacts[0].point;

                //TODO Создаем новый объект из префаба на месте столкновения, немного выше
                //! GetObjectFromPool();
                //? вместо Instantiate
                GameObject replacementObject = Instantiate(biggerReplacementPrefab, collisionPoint + Vector3.up, Quaternion.identity);

                // Устанавливаем новый ID для нового шара
                DefaultLogic newBallLogic = replacementObject.GetComponent<DefaultLogic>();
                newBallLogic.id = id + 1;

                // Уничтожаем текущий шар
                poolManager.ReturnObjectToPool(gameObject);
            }
            else
            {
                // Если ID текущего шара больше или равен ID другого шара, то удаляем другой шар
                poolManager.ReturnObjectToPool(gameObject);
            }
        }
    }
}