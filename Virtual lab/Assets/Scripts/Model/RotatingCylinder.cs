using UnityEngine;

public class RotatingCylinder : MonoBehaviour
{
    public enum RotationType { InPlace, Unscrew }

    [Header("Настройки вращения")]
    [SerializeField] private RotationType rotationType = RotationType.InPlace;
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float maxMoveDistance = 0.6f;
    [SerializeField] private Color highlightColor = Color.yellow;

    private bool isSelected = false;
    private Vector3 initialPosition;
    private float currentMoveDistance = 0f;
    private Material originalMaterial;
    private Material highlightMaterial;
    private Renderer objectRenderer;

    void Start()
    {
        initialPosition = transform.position;
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;

        highlightMaterial = new Material(Shader.Find("Standard"));
        highlightMaterial.color = highlightColor;
        highlightMaterial.EnableKeyword("_EMISSION");
        highlightMaterial.SetColor("_EmissionColor", highlightColor * 0.5f);
    }

    void Update()
    {
        if (isSelected)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll != 0)
            {
                switch (rotationType)
                {
                    case RotationType.InPlace:
                        transform.Rotate(0, rotationSpeed * scroll * Time.deltaTime * 100f, 0);
                        break;

                    case RotationType.Unscrew:
                        float rotationDirection = Mathf.Sign(scroll);
                        transform.Rotate(0, rotationSpeed * rotationDirection * Time.deltaTime * 100f, 0);

                        float moveAmount = moveSpeed * scroll * Time.deltaTime * 100f;
                        float newMoveDistance = Mathf.Clamp(currentMoveDistance + moveAmount, 0f, maxMoveDistance);

                        if (newMoveDistance != currentMoveDistance)
                        {
                            currentMoveDistance = newMoveDistance;
                            transform.position = initialPosition + Vector3.right * currentMoveDistance;
                        }
                        break;
                }
            }
        }
    }

    void OnMouseDown()
    {
        ToggleSelection();
    }

    private void ToggleSelection()
    {
        isSelected = !isSelected;

        if (isSelected)
        {
            objectRenderer.material = highlightMaterial;
            DisableCameraZoom();
        }
        else
        {
            objectRenderer.material = originalMaterial;
            EnableCameraZoom();
        }
    }

    private void DisableCameraZoom()
    {
        UserCamera userCamera = FindFirstObjectByType<UserCamera>();
        if (userCamera != null)
        {
            userCamera.SetZoomEnabled(false);
        }
    }

    private void EnableCameraZoom()
    {
        UserCamera userCamera = FindFirstObjectByType<UserCamera>();
        if (userCamera != null)
        {
            userCamera.SetZoomEnabled(true);
        }
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
        currentMoveDistance = 0f;
    }

    void OnDestroy()
    {
        if (isSelected)
        {
            EnableCameraZoom();
        }

        if (highlightMaterial != null)
        {
            Destroy(highlightMaterial);
        }
    }
}