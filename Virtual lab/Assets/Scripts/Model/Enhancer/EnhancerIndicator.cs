using TMPro;
using UnityEngine;

public class EnhancerIndicator : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject arrow;
    [SerializeField] private EnhancerRotarySwitch rotarySwitch;

    [Header("Углы")]
    [SerializeField] private float localAngle;
    [SerializeField] private float trueAngle;
    [Header("Итоговое число")]
    [SerializeField] private float trueNumber;

    private void FixedUpdate()
    {
        localAngle = rotarySwitch.mouseTurn.x;
        trueAngle = Mathf.Abs(localAngle) - 50f;

        if (rotarySwitch.CurrentEnhancerState) //enhancer on/off
        {
            indicator.SetActive(true);
            UpdatePosition(trueAngle);
        }
        else
        {
            indicator.SetActive(false);
        }
    }

    private void UpdatePosition(float angle)
    {
        arrow.transform.localRotation = Quaternion.Euler(0, 0, -angle);
    }
}
