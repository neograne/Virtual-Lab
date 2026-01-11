using UnityEngine;

public class MathCore: MonoBehaviour
{
    // CONSTANTS
    public const float waveguideRadius = 0.015f; // Радиус волновода (a) - м
    public const int lightSpeed = 300000000; // Скорость света (c) - м/c
    public const float pinDistance = 0.169f; // Расстояние до штыря (z_ш) - м
    public const float suppressionCoefficient = 0.5f; // Коэффициент подавления Н11 (p_под) - нет СИ
    public const float amplificationCoefficient = 1.0f; // Коэффициент усиления приемника Н11 (n_н) - нет СИ
    //public const int scaleCoefficient = 1; // Масштабный коэффициент (С) - нет СИ
    public const float firstCoeffH11 = 1.841f; //Первый корень Бесселя для x_H11
    public const float firstCoeffE01 = 2.405f; //Первый корень Бесселя для x_E01
    
    public const float critWaveH11 = 0.0512f; //критические длины волн
    public const float critWaveE01 = 0.0392f;
    public const long critFreqH11 = 5863057324; //критические частоты
    public const long critFreqE01 = 7659235668;

    public const float normPforH11 = 9.2736f; //амплитуда поля
    public const float normPforE01 = 9.3808f;

    // LINKS
    [Header("Enhancer")]
    [SerializeField] private EnhancerIndicator enhancerIndicator;
    [SerializeField] private EnhancerButton enhancerButton;
    [SerializeField] private EnhancerButtonZero enhancerButtonZero;
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
    [SerializeField] private Section6 section6;
    [Header("UI")]
    [SerializeField] private ModeChanger modeChanger;

    // PARAMETERS
    [Header("Выходящие параметры")]
    //[SerializeField] private float linearGeneratorCoeff;
    [SerializeField] private float fullDistance;
    [SerializeField] private float angleRad;

    [SerializeField] private float waveLength;
    [SerializeField] private float waveLengthE01;
    [SerializeField] private float waveLengthH11;

    [SerializeField] private float waveCoefficient;

    //[SerializeField] private float baseSignal;
    [SerializeField] public float outputPower;
    [SerializeField] private float debugNumber;

    private void FixedUpdate()
    {
        TransformInputParameters();
        CalculateWaveParameters();
        CalculateWaveCoefficients();
        CalculateOutputPower();
    }

    private void TransformInputParameters()
    {
        // 3.1
        //linearGeneratorCoeff = Mathf.Pow(10, (indicatorDb.indicatorNumber / 20)); // Линейный коэффициент генератора
        fullDistance = pinDistance - rotatingPiston.truePosition; // Полное расстояние
        angleRad = section6.trueAngle * (Mathf.PI / 180); // Угол в радианах
    }

    private void CalculateWaveParameters()
    {
        // 3.2
        if (indicatorMhz.indicatorTrueNumber != 0)
            waveLength = lightSpeed / (indicatorMhz.indicatorTrueNumber * 1000000);
        else
            waveLength = 0;
        waveLengthE01 = (indicatorMhz.indicatorTrueNumber * 1000000) > critFreqE01 ? waveLength / Mathf.Sqrt(1 - Mathf.Pow(waveLength / critWaveE01, 2)) : 0;
        waveLengthH11 = (indicatorMhz.indicatorTrueNumber * 1000000) > critFreqH11 ? waveLength / Mathf.Sqrt(1 - Mathf.Pow(waveLength / critWaveH11, 2)) : 0;
    }

    private void CalculateWaveCoefficients()
    {
        // 3.3
        if (modeChanger.currentMode == "Одноволновой") // Плавный переход
        {
            waveCoefficient = normPforH11 * Mathf.Cos(angleRad) * Mathf.Sin(((2 * Mathf.PI) / waveLengthH11) * fullDistance);
        }
        else if (modeChanger.currentMode == "Двухволновой") // Ступенчатый переход
        {
            waveCoefficient = suppressionCoefficient * normPforE01 * Mathf.Sin(((2 * Mathf.PI) / waveLengthE01) * fullDistance) 
                + normPforH11 * Mathf.Cos(angleRad) * Mathf.Sin(((2 * Mathf.PI) / waveLengthH11) * fullDistance);
        }
        else
        {
            Debug.Log("Что-то сильно пошло не так");
        }
    }

    private void CalculateOutputPower()
    {
        // 3.4
        if (generatorButton.generatorState)
        {
            outputPower = amplificationCoefficient * Mathf.Abs(Mathf.Pow(waveCoefficient, 2)) + (BoolToInt(enhancerButtonZero.enhancerZeroState) * enhancerIndicator.trueNumber);
        }
        else 
        {
            outputPower = 0f;
        }
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
