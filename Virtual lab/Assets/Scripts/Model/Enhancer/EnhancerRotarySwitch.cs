using Unity.VisualScripting;
using UnityEngine;


public class EnhancerRotarySwitch : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private EnhancerButton button;
    [SerializeField] private EnhancerButtonZero buttonZero;
    [SerializeField] private GameObject rotarySwitch;
    [Header("Углы")]
    [SerializeField] private float maxAngle = 0f;
    [SerializeField] private float minAngle = -100f;
    [Header("Подсветка")]
    [SerializeField] private Material glowMaterial;
    [Header("DEBUG")]
    [SerializeField] public Vector2 mouseTurn;
    [SerializeField] public float trueAngle;
    private bool currentEnhancerState;
    private bool currentEnhancerStateZero;
    private Renderer rotarySwitchRenderer;
    private Material[] originalMaterials;

    public bool CurrentEnhancerState
    {
        get => currentEnhancerState;
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

        rotarySwitch.transform.rotation = Quaternion.Euler(-Random.Range(4f, 15f), -90, 0);
    }

    private void Update()
    {
        if (button != null)
        {
            if (currentEnhancerState != button.enhancerState)
                currentEnhancerState = button.enhancerState;

            if (currentEnhancerStateZero != buttonZero.enhancerZeroState)
                currentEnhancerStateZero = buttonZero.enhancerZeroState;
            UpdateMaterials();
        }
    }

    private void OnMouseDrag()
    {
        if (currentEnhancerState && Input.GetMouseButton(0) && currentEnhancerStateZero)
        {
            mouseTurn.x -= Input.GetAxis("Mouse X");
            mouseTurn.x = Mathf.Clamp(mouseTurn.x, minAngle, maxAngle);
            rotarySwitch.transform.rotation = Quaternion.Euler(mouseTurn.x, -90, 0);
            trueAngle = Mathf.RoundToInt(100f - 1.01f * (mouseTurn.x + 100f));
        }
    }
    private void UpdateMaterials()
    {
        if (currentEnhancerState && currentEnhancerStateZero)
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
        mouseTurn.x = 0f;
        rotarySwitch.transform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
