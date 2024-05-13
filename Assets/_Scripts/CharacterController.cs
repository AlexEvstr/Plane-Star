using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5.0f; // Скорость движения персонажа
    public GameObject directionArrow; // Объект стрелки на сцене
    public float rotationReturnSpeed = 2.0f; // Скорость возврата вращения
    public float rotationSpeed = 5.0f; // Скорость плавного вращения

    private Vector3 startTouchPosition; // Начальная позиция касания
    private Vector3 moveDirection = Vector3.zero; // Направление движения
    private bool isMoving = false; // Переменная для отслеживания состояния движения
    private Quaternion initialRotation; // Начальное положение вращения
    private Quaternion targetRotation; // Целевое положение вращения

    void Start()
    {
        initialRotation = transform.rotation; // Сохраняем начальное положение вращения
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Получаем первое касание

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z));
                    directionArrow.SetActive(true); // Активируем стрелку
                    break;

                case TouchPhase.Moved:
                    Vector3 currentTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z));
                    moveDirection = (currentTouchPosition - startTouchPosition).normalized;
                    isMoving = true;

                    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                    targetRotation = Quaternion.Euler(0, 0, angle);
                    directionArrow.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                    break;

                case TouchPhase.Ended:
                    isMoving = false;
                    moveDirection = Vector3.zero;
                    directionArrow.SetActive(false); // Деактивируем стрелку
                    break;
            }
        }

        if (isMoving)
        {
            transform.position += moveDirection * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Плавно возвращаем персонажа в начальное положение вращения
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, rotationReturnSpeed * Time.deltaTime);
        }
    }
}