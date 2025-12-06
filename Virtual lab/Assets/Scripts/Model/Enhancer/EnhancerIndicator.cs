using TMPro;
using UnityEngine;

public class EnhancerIndicator : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject arrow;
    [SerializeField] private EnhancerRotarySwitch rotarySwitch;
    [SerializeField] private TextMeshPro resultNumber; 

    [Header("Углы")]
    [SerializeField] private float localAngle;
    [SerializeField] private float trueAngle;
    [Header("Итоговое число")]
    [SerializeField] public int trueNumber;

    private void FixedUpdate()
    {
        localAngle = rotarySwitch.mouseTurn.x;
        trueAngle = Mathf.Abs(localAngle) - 50f;
        trueNumber = Mathf.RoundToInt(Mathf.Abs(localAngle));

        if (rotarySwitch.CurrentEnhancerState) //enhancer on/off
        {
            indicator.SetActive(true);
            UpdatePosition(trueAngle);
            UpdateNumber(trueNumber);
        }
        else
        {
            indicator.SetActive(false);
        }
    }

    private void UpdateNumber(int number)
    {
        resultNumber.text = number.ToString();
    }

    private void UpdatePosition(float angle)
    {
        arrow.transform.localRotation = Quaternion.Euler(0, 0, -angle);
    }
}
