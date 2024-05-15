using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Camera camera; // Камера
    public float speed = 5.0f; // Скорость перемещения объекта
    public float minX = -10.0f; // Минимальное значение X
    public float maxX = 10.0f; // Максимальное значение X
    public float minZ = -10.0f; // Минимальное значение Z
    public float maxZ = 10.0f; // Максимальное значение Z

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Обработка горизонтального ввода
        float vertical = Input.GetAxis("Vertical"); // Обработка вертикального ввода

        // Преобразование ввода в пространство камеры
        Vector3 inputDirection = new (horizontal, 0, vertical);
        Vector3 movementDirection = camera.transform.TransformDirection(inputDirection);
        movementDirection.y = 0; // Убрать движение по Y

        // Вычисление нового положения
        float newX = transform.position.x + movementDirection.x * speed * Time.deltaTime;
        newX = Mathf.Clamp(newX, minX, maxX); // Ограничение по X
        transform.position = new (newX, transform.position.y, transform.position.z);

        // Вычисление нового положения Z
        float newZ = transform.position.z + movementDirection.z * speed * Time.deltaTime;
        newZ = Mathf.Clamp(newZ, minZ, maxZ); // Ограничение по Z
        transform.position = new (transform.position.x, transform.position.y, newZ);
    }
}
