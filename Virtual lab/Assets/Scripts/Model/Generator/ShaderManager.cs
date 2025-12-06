using UnityEngine;

public class ShaderManager : MonoBehaviour
{
    [SerializeField] GeneratorButton generatorButton;
    private bool currentGeneratorState;
    private void Update()
    {
        if (generatorButton != null)
        {
            if (currentGeneratorState != generatorButton.generatorState)
                currentGeneratorState = generatorButton.generatorState;
        }
    }
}
