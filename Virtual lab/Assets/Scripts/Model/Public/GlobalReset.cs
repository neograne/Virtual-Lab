using UnityEngine;

public class GlobalReset : MonoBehaviour
{
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


    public void ResetStation()
    {
        enhancerIndicator.GlobalReset();
        enhancerButton.GlobalReset();
        enhancerRotarySwitch.GlobalReset();

        generatorButton.GlobalReset();
        rotarySwitchMhz.GlobalReset();
        rotarySwitchDb.GlobalReset();
        rotarySwitchMWI.GlobalReset();
        indicatorMhz.GlobalReset();
        indicatorDb.GlobalReset();

        rotatingPiston.GlobalReset();
    }
}
