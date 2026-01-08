using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [Header("Ссылки на слайдеры - Основные")]
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private Slider speedSlider;

    [Header("Ссылки на слайдеры - Зум")]
    [SerializeField] private Slider zoomSpeedSlider;
    [SerializeField] private Slider zoomStrengthSlider;

    [Header("Ссылки на текстовые поля значений")]
    [SerializeField] private TMP_Text sensitivityValueText;
    [SerializeField] private TMP_Text speedValueText;
    [SerializeField] private TMP_Text zoomSpeedValueText;
    [SerializeField] private TMP_Text zoomStrengthValueText;

    [Header("Ссылка на камеру")]
    [SerializeField] private UserCamera userCamera;

    private void Start()
    {
        if (userCamera == null)
            userCamera = FindFirstObjectByType<UserCamera>();

        // Настраиваем диапазоны слайдеров
        ConfigureSliders();

        InitializeSlider(sensitivitySlider, userCamera.LookSensitivity, OnSensitivityChanged);
        InitializeSlider(speedSlider, userCamera.MovementSpeed, OnSpeedChanged);
        InitializeSlider(zoomSpeedSlider, userCamera.ZoomSpeed, OnZoomSpeedChanged);
        InitializeSlider(zoomStrengthSlider, userCamera.ZoomStrength, OnZoomStrengthChanged);

        UpdateDisplayValues();
    }

    private void ConfigureSliders()
    {
        // Скорость зума: 1-20, по умолчанию 5
        if (zoomSpeedSlider != null)
        {
            zoomSpeedSlider.minValue = 1f;
            zoomSpeedSlider.maxValue = 20f;
        }

        if (zoomStrengthSlider != null)
        {
            zoomStrengthSlider.minValue = 1f;
            zoomStrengthSlider.maxValue = 10f;
        }
    }

    private void InitializeSlider(Slider slider, float initialValue, UnityEngine.Events.UnityAction<float> callback)
    {
        if (slider != null)
        {
            slider.value = initialValue;
            slider.onValueChanged.AddListener(callback);
        }
    }

    private void OnSensitivityChanged(float value)
    {
        if (userCamera != null) userCamera.LookSensitivity = value;
        UpdateDisplayValues();
    }

    private void OnSpeedChanged(float value)
    {
        if (userCamera != null) userCamera.MovementSpeed = value;
        UpdateDisplayValues();
    }

    private void OnZoomSpeedChanged(float value)
    {
        if (userCamera != null) userCamera.ZoomSpeed = value;
        UpdateDisplayValues();
    }

    private void OnZoomStrengthChanged(float value)
    {
        if (userCamera != null)
        {
            userCamera.ZoomStrength = value;
            Debug.Log($"Сила зума установлена: {value}");
        }
        UpdateDisplayValues();
    }

    private void UpdateDisplayValues()
    {
        if (userCamera == null) return;

        SetTextIfNotNull(sensitivityValueText, userCamera.LookSensitivity.ToString("F1"));
        SetTextIfNotNull(speedValueText, userCamera.MovementSpeed.ToString("F1"));
        SetTextIfNotNull(zoomSpeedValueText, userCamera.ZoomSpeed.ToString("F1"));
        SetTextIfNotNull(zoomStrengthValueText, userCamera.ZoomStrength.ToString("F1"));
    }

    private void SetTextIfNotNull(TMP_Text textField, string value)
    {
        if (textField != null)
            textField.text = value;
    }

    public void ResetCameraSettingsToDefaults()
    {
        if (userCamera == null) return;

        userCamera.LookSensitivity = 2f;
        userCamera.MovementSpeed = 5f;
        userCamera.ZoomSpeed = 5f;
        userCamera.ZoomStrength = 5f;
        userCamera.ResetZoom();

        sensitivitySlider.value = userCamera.LookSensitivity;
        speedSlider.value = userCamera.MovementSpeed;
        zoomSpeedSlider.value = userCamera.ZoomSpeed;
        zoomStrengthSlider.value = userCamera.ZoomStrength;

        UpdateDisplayValues();
        Debug.Log("Настройки сброшены к значениям по умолчанию");
    }
}