using UnityEngine;

public class GlobalReset : MonoBehaviour
{
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


    public void ResetStation()
    {
        enhancerIndicator.GlobalReset();
        enhancerButton.GlobalReset();
        enhancerButtonZero.GlobalReset();
        enhancerRotarySwitch.GlobalReset();

        generatorButton.GlobalReset();
        rotarySwitchMhz.GlobalReset();
        rotarySwitchDb.GlobalReset();
        rotarySwitchMWI.GlobalReset();
        indicatorMhz.GlobalReset();
        indicatorDb.GlobalReset();

        rotatingPiston.GlobalReset();
        section6.GlobalReset();
    }
}
