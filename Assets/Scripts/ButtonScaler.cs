using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public float scaleFactor = 1.2f; // Множитель для увеличения размера кнопки
    public float animationDuration = 0.2f; // Длительность анимации
    private Vector3 originalScale; // Оригинальный размер кнопки
    private Button button; // Ссылка на компонент кнопки
    private Coroutine scaleCoroutine; // Корутина для управления анимацией

    void Start()
    {
        // Получаем компонент кнопки
        button = GetComponent<Button>();

        // Сохраняем оригинальный размер кнопки
        originalScale = transform.localScale;
    }

    // Вызывается при наведении курсора на кнопку
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Если корутина уже запущена, прерываем её
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        // Запускаем корутину увеличения размера
        scaleCoroutine = StartCoroutine(ScaleButton(originalScale * scaleFactor));
    }

    // Вызывается при отведении курсора с кнопки
    public void OnPointerExit(PointerEventData eventData)
    {
        // Если корутина уже запущена, прерываем её
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        // Запускаем корутину уменьшения размера
        scaleCoroutine = StartCoroutine(ScaleButton(originalScale));
    }

    // Корутина для изменения размера кнопки
    private IEnumerator ScaleButton(Vector3 targetScale)
    {
        float timeElapsed = 0f;
        Vector3 startScale = transform.localScale;

        while (timeElapsed < animationDuration)
        {
            timeElapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, timeElapsed / animationDuration);
            yield return null;
        }

        // Устанавливаем конечный размер
        transform.localScale = targetScale;

        // Корутина завершена
        scaleCoroutine = null;
    }
}