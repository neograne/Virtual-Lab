using UnityEngine;

public class RotatingPiston : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GameObject rotatingPiston;

    [Header("Ограничения движения")]
    [SerializeField] private float minPosition = -1.7f;
    [SerializeField] private float maxPosition = -0.7f;
    [SerializeField] private float maxRotationAngle = 360f;

    [Header("Настройки чувствительности")]
    [SerializeField] private float moveSensitivity = 1f;
    [SerializeField] private float rotationSensitivity = 200f;

    [Header("DEBUG")]
    [SerializeField] private float currentPosition;
    [SerializeField] private float currentRotation;

    private Vector3 lastMousePosition;
    private bool isDragging = false;

    private void OnMouseDown()
    {
        lastMousePosition = Input.mousePosition;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 currentMousePosition = Input.mousePosition;
        float deltaX = currentMousePosition.x - lastMousePosition.x;

        currentPosition -= deltaX * moveSensitivity * 0.01f; // 0.01f для нормализации
        currentPosition = Mathf.Clamp(currentPosition, minPosition, maxPosition);

        currentRotation -= deltaX * rotationSensitivity * 0.01f;
        currentRotation = Mathf.Clamp(currentRotation, 0f, maxRotationAngle);

        rotatingPiston.transform.localPosition = new Vector3(0, currentPosition, 0);
        rotatingPiston.transform.localRotation = Quaternion.Euler(0, currentRotation, 0);

        lastMousePosition = currentMousePosition;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void GlobalReset()
    {
        currentPosition = minPosition; 
        currentRotation = 0f;
        rotatingPiston.transform.localPosition = new Vector3(0, minPosition, 0);
        rotatingPiston.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void SetSensitivity(float moveSens, float rotateSens)
    {
        moveSensitivity = Mathf.Clamp(moveSens, 0.1f, 10f);
        rotationSensitivity = Mathf.Clamp(rotateSens, 50f, 1000f);
    }
}
