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
    [SerializeField] private float trueAngle;
    [Header("Итоговое число")]
    [SerializeField] public int trueNumber;
    private MathCore mathCore;

    private void FixedUpdate()
    {
        mathCore = FindFirstObjectByType<MathCore>();
        trueNumber = Mathf.RoundToInt(mathCore.outputPower);
        trueNumber = Mathf.Clamp(trueNumber, 0, 100);
        trueAngle = -47f - 0.85f * trueNumber;

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
        arrow.transform.localRotation = Quaternion.Euler(angle, 0, 0);
    }

    public void GlobalReset()
    {
        trueAngle = 0f;
        trueNumber = 0;
        resultNumber.text = "0";
        arrow.transform.localRotation = Quaternion.Euler(-47f, 0, 0);
    }
}
