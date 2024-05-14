using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject directionArrow;
    public float rotationReturnSpeed = 2.0f;
    public float rotationSpeed = 5.0f;

    private Vector3 startTouchPosition;
    private Vector3 moveDirection = Vector3.zero;
    private bool isMoving = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z));
                    directionArrow.SetActive(true);
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
                    directionArrow.SetActive(false);
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
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, rotationReturnSpeed * Time.deltaTime);
        }
    }
}
