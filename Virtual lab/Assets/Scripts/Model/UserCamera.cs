using UnityEngine;

public class UserCamera : MonoBehaviour
{   // паблик, чтобы можно было вручную настроить (мб слишком быстро будет)
    [SerializeField] private float movementSpeed = 10; // скорость передвижения
    [SerializeField] private float lookSensitivity = 2; // чувствительность мыши

    private float rotationX = 0;
    private float rotationY = 0;

    void Update()
    {
        // передвижение по карте
        float moveHorizontal = Input.GetAxis("Horizontal"); // A и D
        float moveVertical = Input.GetAxis("Vertical");     // W и S

        // здесь сам вектор движения
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // передвижение камеры 
        transform.position += movement * movementSpeed * Time.deltaTime;

        // вращение обзора
        if (Input.GetMouseButton(1)) // при зажатии пкм
        {
            // входные данные мыши
            rotationX += Input.GetAxis("Mouse X") * lookSensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * lookSensitivity;

            // ограничения, чтобы не перевернуться вверх тормашкой (можно и убрать, если хочешь)
            rotationY = Mathf.Clamp(rotationY, -90f, 90f);

            // вращение
            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);
        }
    }
}
