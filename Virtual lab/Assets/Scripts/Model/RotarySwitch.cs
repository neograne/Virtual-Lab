using UnityEngine;

public class RotarySwitch : MonoBehaviour
{
    [SerializeField] Lever lever;
    [SerializeField] GameObject rotarySwitch;
    private bool currentGeneratorState;
    private float rotationSpeed = 100f;

    private void Awake()
    {
        if (lever == null)
            Debug.LogError("Рычага нет");
    }

    private void Update()
    {
        if (lever != null)
        {
            if (currentGeneratorState != lever.generatorState)
                currentGeneratorState = lever.generatorState;
        }
    }

    private void OnMouseDrag()
    {
        if (currentGeneratorState)
        {
            if (Input.GetMouseButton(0))
            {
                rotarySwitch.transform.Rotate(Vector3.down, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime);
                Debug.Log($"Rotation: {rotarySwitch.transform.localRotation.eulerAngles.x}");
            }
            else
            {
                Debug.Log("Пользователь перестал зажимать лкм");
            }
        }
    }
}
