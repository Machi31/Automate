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

    private string originalText; // Храним исходную строку

    // Use this for initialization
    void Start()
    {
        originalText = "HelloWorld"; // Исходная строка
    }

    // Update is called once per frame
    void Update()
    {
        // Здесь можно добавить логику для обновления текста
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

                // Используем позицию спавна из spawnPos
                Vector3 spawnPosition = spawnPos.transform.position;

                // Создаем новый объект из префаба на месте столкновения, немного выше
                GameObject replacementObject = Instantiate(biggerReplacementPrefab, collisionPoint + Vector3.up, Quaternion.identity);

                // Устанавливаем новый ID для нового шара
                DefaultLogic newBallLogic = replacementObject.GetComponent<DefaultLogic>();
                newBallLogic.id = id + 1;

                // Уничтожаем текущий шар
                poolManager.

                // Заменяем два последних символа исходной строки на точку
                string modifiedText = originalText.Remove(originalText.Length - 2).Insert(originalText.Length - 2, ".");
                Debug.Log(modifiedText); // Выводим модифицированный текст в консоль
            }
            else
            {
                // Если ID текущего шара больше или равен ID другого шара, то удаляем другой шар
                Destroy(collision.gameObject);
            }
        }
    }
}