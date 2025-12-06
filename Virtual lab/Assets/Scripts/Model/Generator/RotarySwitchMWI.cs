using UnityEngine;

public class RotarySwitchMWI : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GeneratorButton button;
    [SerializeField] private GameObject rotarySwitch;
    [Header("Углы")]
    [SerializeField] private float maxAngle = -90f;
    [SerializeField] private float minAngle = -270f;
    [Header("Подсветка")]
    [SerializeField] private Material glowMaterial;
    [Header("DEBUG")]
    [SerializeField] public Vector2 mouseTurn;
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
            mouseTurn.x -= Input.GetAxis("Mouse X");
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
        mouseTurn.x = -90;
        rotarySwitch.transform.localRotation = Quaternion.Euler(-90, 0, 0);
    }
}
