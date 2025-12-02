using UnityEngine;

public class RotarySwitch : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GeneratorButton button;
    [SerializeField] private GameObject rotarySwitch;
    [Header("Углы")]
    [SerializeField] private float maxAngle = -60f; 
    [SerializeField] private float minAngle = -240f;
    [Header("DEBUG")]
    [SerializeField] public Vector2 mouseTurn;
    private bool currentGeneratorState;

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
            mouseTurn.x -= Input.GetAxis("Mouse X");
            mouseTurn.x = Mathf.Clamp(mouseTurn.x, minAngle, maxAngle);
            rotarySwitch.transform.localRotation = Quaternion.Euler(mouseTurn.x, 0, 0);
        }
        else
        {
            //GeneratorReset()
        }
    }
}