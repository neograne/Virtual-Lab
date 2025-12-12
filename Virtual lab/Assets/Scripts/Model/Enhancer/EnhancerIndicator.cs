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

    private float constCoefficient = 100f / 86f;

    private void FixedUpdate()
    {
        localAngle = rotarySwitch.mouseTurn.x;
        trueAngle = Mathf.Abs(localAngle);
        trueNumber = Mathf.RoundToInt(Mathf.Abs(localAngle) * constCoefficient);

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
        arrow.transform.localRotation = Quaternion.Euler(-angle - 47, 0, 0);
    }

    public void GlobalReset()
    {
        localAngle = 0f;
        trueAngle = 0f;
        trueNumber = 0;
        resultNumber.text = "0";
        arrow.transform.localRotation = Quaternion.Euler(-47f, 0, 0);
    }
}
