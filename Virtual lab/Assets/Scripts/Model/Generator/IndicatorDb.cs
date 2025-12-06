using TMPro;
using UnityEngine;

public class IndicatorDb : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GameObject indicatorDb;
    [SerializeField] private RotarySwitchDb switchDb;
    [Header("Углы")]
    [SerializeField] private float localAngle;
    [SerializeField] private float trueAngle;
    [Header("Полное число на табло")]
    [SerializeField] private int indicatorNumber;
    [Header("Цифры на табло")]
    [SerializeField] private TMP_Text firstDigit;
    [SerializeField] private TMP_Text secondDigit;
    [SerializeField] private TMP_Text thirdDigit;
    [SerializeField] private TMP_Text lastDigit;

    private float constCoefficient = 9999 / 180;

    private void Awake()
    {
        if (indicatorDb == null)
        {
            indicatorDb = this.gameObject;
        }

        if (indicatorDb == null)
        {
            Debug.LogError("IndicatorDb не найден");
            return;
        }

        if (firstDigit == null)
        {
            Transform child = indicatorDb.transform.Find("Тысячи");
            if (child != null) firstDigit = child.GetComponent<TMP_Text>();
            else Debug.LogWarning("Не найден дочерний элемент Тысячи");
        }

        if (secondDigit == null)
        {
            Transform child = indicatorDb.transform.Find("Сотни");
            if (child != null) secondDigit = child.GetComponent<TMP_Text>();
            else Debug.LogWarning("Не найден дочерний элемент Сотни");
        }
        if (thirdDigit == null)
        {
            Transform child = indicatorDb.transform.Find("Десятки");
            if (child != null) thirdDigit = child.GetComponent<TMP_Text>();
            else Debug.LogWarning("Не найден дочерний элемент Десятки");
        }

        if (lastDigit == null)
        {
            Transform child = indicatorDb.transform.Find("Единицы");
            if (child != null) lastDigit = child.GetComponent<TMP_Text>();
            else Debug.LogWarning("Не найден дочерний элемент Единицы");
        }

        if (firstDigit == null || secondDigit == null || thirdDigit == null || lastDigit == null)
        {
            Debug.LogError("Все плохо");
        }
    }

    private void FixedUpdate()
    {
        localAngle = switchDb.mouseTurn.x;
        trueAngle = Mathf.Abs(localAngle) - 90f;

        indicatorNumber = Mathf.RoundToInt(trueAngle * constCoefficient);
        if (switchDb.CurrentGeneratorState) //generator on/off
        {
            UpdateNumber(indicatorNumber);
        }
        else
        {
            UpdateNumber(0);
        }
    }

    private void UpdateNumber(int number)
    {
        if (trueAngle == 180)
            number = 9999;
        else if (trueAngle == 0)
            number = 0;

        firstDigit.text = (number / 1000).ToString();
        secondDigit.text = ((number / 100) % 10).ToString();
        thirdDigit.text = ((number / 10) % 10).ToString();
        lastDigit.text = (number % 10).ToString();
    }

    public void GlobalReset()
    {

    }
}
