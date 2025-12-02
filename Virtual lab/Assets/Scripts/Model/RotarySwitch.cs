using UnityEngine;

public class RotarySwitch : MonoBehaviour
{
    [SerializeField] private GeneratorButton button;
    [SerializeField] private GameObject rotarySwitch;
    [SerializeField] private float maxAngle = 120f; 
    [SerializeField] private float minAngle = -60f;
    [SerializeField] private float yTurn;
    private bool currentGeneratorState;
    [SerializeField] private Vector2 mouseTurn; //DEBUG

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
            mouseTurn.x += Input.GetAxis("Mouse X");
            mouseTurn.x = Mathf.Clamp(mouseTurn.x, minAngle, maxAngle);
            rotarySwitch.transform.localRotation = Quaternion.Euler(mouseTurn.x, yTurn, 0);
        }
    }
}