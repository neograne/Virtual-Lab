using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class SettingsManager : MonoBehaviour
{
    [Header("Ссылки на слайдеры")]
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private Slider speedSlider;

    [Header("Ссылки на текстовые поля значений")]
    [SerializeField] private TMP_Text sensitivityValueText; 
    [SerializeField] private TMP_Text speedValueText;      

    [Header("Ссылка на камеру")]
    [SerializeField] private UserCamera userCamera;

    private void Start()
    {
        if (userCamera == null)
            userCamera = FindFirstObjectByType<UserCamera>();

        if (sensitivitySlider != null)
        {
            sensitivitySlider.value = userCamera.LookSensitivity;
            sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        }

        if (speedSlider != null)
        {
            speedSlider.value = userCamera.MovementSpeed;
            speedSlider.onValueChanged.AddListener(OnSpeedChanged);
        }

        UpdateDisplayValues();
    }

    private void OnSensitivityChanged(float value)
    {
        userCamera.LookSensitivity = value;
        UpdateDisplayValues();
    }

    private void OnSpeedChanged(float value)
    {
        userCamera.MovementSpeed = value;
        UpdateDisplayValues();
    }

    private void UpdateDisplayValues()
    {
        if (sensitivityValueText != null)
            sensitivityValueText.text = userCamera.LookSensitivity.ToString("F1");

        if (speedValueText != null)
            speedValueText.text = userCamera.MovementSpeed.ToString("F1");
    }
}