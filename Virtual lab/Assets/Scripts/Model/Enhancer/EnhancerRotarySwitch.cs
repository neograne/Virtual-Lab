using UnityEngine;

public class EnhancerRotarySwitch : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private EnhancerButton button;
    [SerializeField] private GameObject rotarySwitch;
    [Header("Углы")]
    [SerializeField] private float maxAngle = 100f;
    [SerializeField] private float minAngle = 0f;
    [Header("DEBUG")]
    [SerializeField] public Vector2 mouseTurn;
    private bool currentEnhancerState;

    public bool CurrentEnhancerState
    {
        get => currentEnhancerState;
    }

    private void Update()
    {
        if (button != null)
        {
            if (currentEnhancerState != button.enhancerState)
                currentEnhancerState = button.enhancerState;
        }
    }

    private void OnMouseDrag()
    {
        if (currentEnhancerState && Input.GetMouseButton(0))
        {
            mouseTurn.x -= Input.GetAxis("Mouse X");
            mouseTurn.x = Mathf.Clamp(mouseTurn.x, minAngle, maxAngle);
            rotarySwitch.transform.rotation = Quaternion.Euler(mouseTurn.x, -90, 0);
        }
    }

    public void GlobalReset()
    {
        mouseTurn.x = 0f;
        rotarySwitch.transform.rotation = Quaternion.Euler(0f, -90, 0);
    }
}
