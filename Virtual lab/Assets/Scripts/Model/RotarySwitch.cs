using UnityEngine;

public class RotarySwitch : MonoBehaviour
{
    [SerializeField] private GeneratorButton button;
    [SerializeField] private GameObject rotarySwitch;
    [SerializeField] private int minAngle = 300;
    [SerializeField] private int maxAngle = 60;
    private bool currentGeneratorState;
    private float rotationSpeed = 200f;

    private void Update()
    {
        if (button != null)
        {
            if (currentGeneratorState != button.generatorState)
                currentGeneratorState = button.generatorState;
        }
    }

    private void OnMouseDrag()
    {
        if (currentGeneratorState && Input.GetMouseButton(0))
        {
            //dont work
            if (rotarySwitch.transform.localRotation.eulerAngles.x == minAngle) 
            {
                Debug.Log("Достигнуто минимальное значение");
            }
            else if (rotarySwitch.transform.localRotation.eulerAngles.x == maxAngle)
            {
                Debug.Log("Достигнуто максимальное значение");
            }
            else
            {
                rotarySwitch.transform.Rotate(new(-1, 0, 0), Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime);
                Debug.Log($"Rotation: {rotarySwitch.transform.localRotation.eulerAngles.x}");
            }
        }
    }
}
