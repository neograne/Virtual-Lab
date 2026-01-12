using UnityEngine;

public class RotarySwitchMhz : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GeneratorButton button;
    [SerializeField] private GameObject rotarySwitch;
    [Header("Углы")]
    [SerializeField] private float maxAngle = 0f; 
    [SerializeField] private float minAngle = -300f;
    [Header("Подсветка")]
    [SerializeField] private Material glowMaterial;
    [Header("DEBUG")]
    [SerializeField] public Vector2 mouseTurn;
    [SerializeField] private float fineSensitivity = 0.001f;
    [SerializeField] private float normalSensitivity = 1f;
    private bool currentGeneratorState;
    private Renderer rotarySwitchRenderer;
    private Material[] originalMaterials;
    

    public bool CurrentGeneratorState
    {
        get => currentGeneratorState;
    }

    private void Awake()
    {
        if (rotarySwitch != null)
        {
            rotarySwitchRenderer = rotarySwitch.GetComponent<Renderer>();
            originalMaterials = rotarySwitchRenderer.sharedMaterials;
        }
        else
        {
            Debug.LogError("Префаб съели волки");
        }

        if (glowMaterial == null)
        {
            Debug.LogError("Префаб погрызли собаки");
        }
    }

    private void Update()
    {
        if (button != null)
        {
            if (currentGeneratorState != button.generatorState)
                currentGeneratorState = button.generatorState;
            UpdateMaterials();
        }
    }

    private void OnMouseDrag()
    {
        if (currentGeneratorState && Input.GetMouseButton(0))
        {
            float sens = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)
                ? fineSensitivity
                : normalSensitivity;

            float deltaX = Input.GetAxis("Mouse X");
            mouseTurn.x -= deltaX * sens;
            mouseTurn.x = Mathf.Clamp(mouseTurn.x, minAngle, maxAngle);
            rotarySwitch.transform.localRotation = Quaternion.Euler(mouseTurn.x, 0, 0);
        }
    }

    private void UpdateMaterials()
    {
        if (currentGeneratorState)
        {
            Material[] newMaterials = new Material[originalMaterials.Length + 1];
            for (int i = 0; i < originalMaterials.Length; i++)
            {
                newMaterials[i] = originalMaterials[i];
            }
            newMaterials[originalMaterials.Length] = glowMaterial;
            rotarySwitchRenderer.materials = newMaterials;
        }
        else
        {
            rotarySwitchRenderer.materials = originalMaterials;
        }
    }

    public void GlobalReset()
    {
        mouseTurn.x = 0;
        rotarySwitch.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}