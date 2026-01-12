using TMPro;
using UnityEngine;

public class IndicatorMhz : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GameObject indicatorMhz;
    [SerializeField] private RotarySwitchMhz switchMhz;
    [SerializeField] private GameObject dial;
    [Header("Углы")]
    [SerializeField] private float localAngle;
    [SerializeField] private float trueAngle;
    [Header("Полное число на табло")]
    [SerializeField] public int indicatorNumber;
    public float indicatorTrueNumber;
    [Header("Цифры на табло")]
    [SerializeField] private TMP_Text firstDigit;
    [SerializeField] private TMP_Text secondDigit;
    [SerializeField] private TMP_Text thirdDigit;
    [SerializeField] private TMP_Text fourthDigit;
    [SerializeField] private TMP_Text lastDigit;

    private void Awake()
    {
        if (indicatorMhz == null)
        {
            indicatorMhz = this.gameObject;
        }

        if (indicatorMhz == null)
        {
            Debug.LogError("IndicatorMhz не найден");
            return;
        }

        if (firstDigit == null)
        {
            Transform child = indicatorMhz.transform.Find("Десятки тысяч");
            if (child != null) firstDigit = child.GetComponent<TMP_Text>();
            else Debug.LogWarning("Не найден дочерний элемент Десятки тысяч");
        }

        if (secondDigit == null)
        {
            Transform child = indicatorMhz.transform.Find("Тысячи");
            if (child != null) secondDigit = child.GetComponent<TMP_Text>();
            else Debug.LogWarning("Не найден дочерний элемент Тысячи");
        }
        if (thirdDigit == null)
        {
            Transform child = indicatorMhz.transform.Find("Сотни");
            if (child != null) thirdDigit = child.GetComponent<TMP_Text>();
            else Debug.LogWarning("Не найден дочерний элемент Сотни");
        }

        if (fourthDigit == null)
        {
            Transform child = indicatorMhz.transform.Find("Десятки");
            if (child != null) fourthDigit = child.GetComponent<TMP_Text>();
            else Debug.LogWarning("Не найден дочерний элемент Десятки");
        }

        if (lastDigit == null)
        {
            Transform child = indicatorMhz.transform.Find("Единицы");
            if (child != null) lastDigit = child.GetComponent<TMP_Text>();
            else Debug.LogWarning("Не найден дочерний элемент Единицы");
        }

        if (firstDigit == null || secondDigit == null || thirdDigit == null || fourthDigit == null || lastDigit == null)
        {
            Debug.LogError("Все плохо");
        }
    }

    private void FixedUpdate()
    {
        localAngle = switchMhz.mouseTurn.x;
        trueAngle = Mathf.Abs(localAngle);
        indicatorTrueNumber = 333.33f * trueAngle;
        indicatorNumber = Mathf.RoundToInt(333.33f * trueAngle);
        if (switchMhz.CurrentGeneratorState) //generator on/off
        {
            dial.SetActive(true);
            UpdateNumber(indicatorNumber);
        }
        else
        {
            dial.SetActive(false);
            UpdateNumber(0);
        }
    }

    private void UpdateNumber(int number)
    {
        if (trueAngle == 180)
            number = 99999;
        else if (trueAngle == 0)
            number = 0;

        firstDigit.text = (number / 10000).ToString();
        secondDigit.text = ((number / 1000) % 10).ToString();
        thirdDigit.text = ((number / 100) % 10).ToString();
        fourthDigit.text = ((number / 10) % 10).ToString();
        lastDigit.text = (number % 10).ToString();
    }

    public void GlobalReset()
    {

    }
}
