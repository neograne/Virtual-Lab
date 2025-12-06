using UnityEngine;

public class RotarySwitchMWI : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GeneratorButton button;
    [SerializeField] private GameObject rotarySwitch;
    [Header("Углы")]
    [SerializeField] private float maxAngle = -90f;
    [SerializeField] private float minAngle = -270f;
    [Header("DEBUG")]
    [SerializeField] public Vector2 mouseTurn;
    private bool currentGeneratorState;

    public bool CurrentGeneratorState
    {
        get => currentGeneratorState;
    }

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
    }

    public void GlobalReset()
    {
        mouseTurn.x = -90;
        rotarySwitch.transform.localRotation = Quaternion.Euler(-90, 0, 0);
    }
}
