using UnityEngine;

public class MathCore: MonoBehaviour
{
    // CONSTANTS
    public const float waveguideRadius = 0.015f; // Радиус волновода (a) - м
    public const int lightSpeed = 300000000; // Скорость света (c) - м/c
    public const float pinDistance = 0.169f; // Расстояние до штыря (z_ш) - м
    public const float suppressionCoefficient = 0.5f; // Коэффициент подваления Н11 (p_под) - нет СИ
    public const float amplificationCoefficient = 1.0f; // Коэффициент усиления приемника Н11 (n_н) - нет СИ
    public const int scaleCoefficient = 1000; // Масштабный коэффициент (С) - нет СИ

    // LINKS
    [Header("Enhancer")]
    [SerializeField] private EnhancerIndicator enhancerIndicator;
    [SerializeField] private EnhancerButton enhancerButton;
    [SerializeField] private EnhancerRotarySwitch enhancerRotarySwitch;
    [Header("Generator")]
    [SerializeField] private GeneratorButton generatorButton;
    [SerializeField] private RotarySwitchMhz rotarySwitchMhz;
    [SerializeField] private RotarySwitchDb rotarySwitchDb;
    [SerializeField] private RotarySwitchMWI rotarySwitchMWI;
    [SerializeField] private IndicatorMhz indicatorMhz;
    [SerializeField] private IndicatorDb indicatorDb;
    [Header("Section 6")]
    [SerializeField] private RotatingPiston rotatingPiston;
    [Header("UI")]
    [SerializeField] private ModeChanger modeChanger;

    // PARAMETERS
    [Header("Выходящие параметры")]
    [SerializeField] private float linearGeneratorCoeff;
    [SerializeField] private float fullDistance;
    [SerializeField] private float angleRad;

    [SerializeField] private float waveLength;
    [SerializeField] private float waveLengthE01;
    [SerializeField] private float waveLengthH11;

    [SerializeField] private float waveCoefficient;

    [SerializeField] private float baseSignal;
    [SerializeField] private float outputPower;

    private void FixedUpdate()
    {
        //TransformInputParameters();
        CalculateWaveParameters();
        //CalculateWaveCoefficients();
        //CalculateOutputPower();
    }

    private void TransformInputParameters()
    {
        // 3.1
        // скорее всего неверно
        linearGeneratorCoeff = Mathf.Pow(10, (indicatorDb.indicatorNumber / 20)); // Линейный коэффициент генератора
        //fullDistance = zkz + pinDistance // Полное расстояние - z
        //angleRad = anglekz * (Mathf.PI / 180); // Угол в радианах
    }

    private void CalculateWaveParameters()
    {
        // 3.2
        waveLength = lightSpeed / (indicatorMhz.indicatorNumber * Mathf.Pow(10, 6));
        waveLengthE01 = waveLength / Mathf.Sqrt(1 - Mathf.Pow(waveLength / 2.613f * waveguideRadius, 2));
        waveLengthH11 = waveLength / Mathf.Sqrt(1 - Mathf.Pow(waveLength / 3.413f * waveguideRadius, 2));
    }

    private void CalculateWaveCoefficients()
    {
        // 3.3
        if (modeChanger.currentMode == "Одноволновой") // Плавный переход
        {
            waveCoefficient = Mathf.Sin(angleRad) * Mathf.Sin(((2 * Mathf.PI) / waveLengthH11) * fullDistance);
        }
        else if (modeChanger.currentMode == "Двухволновой") // Ступенчатый переход
        {
            waveCoefficient = suppressionCoefficient * Mathf.Sin(angleRad) * Mathf.Sin(((2 * Mathf.PI) / waveLengthH11) * fullDistance)
                + 1 * Mathf.Sin(((2 * Mathf.PI) / waveLengthE01) * fullDistance);
        }
        else
        {
            Debug.Log("Что-то сильно пошло не так");
        }
    }

    private void CalculateOutputPower()
    {
        // 3.4
        // скорее всего неверно
        baseSignal = linearGeneratorCoeff * amplificationCoefficient * Mathf.Abs(waveCoefficient)
            * (1 - BoolToInt(enhancerButton.enhancerState)) * BoolToInt(generatorButton.generatorState) + enhancerIndicator.trueNumber;
        //outputPower = K_scale * Mathf.Pow(baseSignal, 2) * scaleCoefficient;
    }



    private int BoolToInt(bool value)
    {
        switch (value)
        {
            case true:
                return 1;
            case false:
                return 0;
        }
    }
}
