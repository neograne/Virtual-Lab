using UnityEngine;

public class UserCamera : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float lookSensitivity = 2f;

    [Header("Zoom")]
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float zoomStrength = 10f;
    [SerializeField] private float minFOV = 10f;
    [SerializeField] private float maxFOV = 60f;
    [SerializeField] private bool zoomEnabled = true;

    private Camera playerCamera;
    private Rigidbody rb;
    private float currentFOV;
    private float originalFOV;
    private float rotationX = 0f;
    private float rotationY = 0f;

    public float MovementSpeed
    {
        get => movementSpeed;
        set => movementSpeed = Mathf.Clamp(value, 1f, 20f);
    }

    public float LookSensitivity
    {
        get => lookSensitivity;
        set => lookSensitivity = Mathf.Clamp(value, 0.5f, 5f);
    }

    public float ZoomSpeed
    {
        get => zoomSpeed;
        set => zoomSpeed = Mathf.Clamp(value, 1f, 20f);
    }

    public float ZoomStrength
    {
        get => zoomStrength;
        set
        {
            zoomStrength = Mathf.Clamp(value, 5f, 60f);
            UpdateMinFOV();
        }
    }

    void Start()
    {
        playerCamera = GetComponent<Camera>();
        if (playerCamera == null)
            playerCamera = GetComponentInChildren<Camera>();

        if (playerCamera != null)
        {
            currentFOV = playerCamera.fieldOfView;
            originalFOV = currentFOV;
            maxFOV = currentFOV;
            UpdateMinFOV();
        }

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        rotationX = transform.eulerAngles.y;
        rotationY = transform.eulerAngles.x;
    }

    void Update()
    {
        HandleRotation();
        HandleZoom();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void UpdateMinFOV()
    {
        if (playerCamera == null) return;

        minFOV = originalFOV / (zoomStrength / 10f);
        minFOV = Mathf.Clamp(minFOV, 5f, originalFOV * 2f);

        currentFOV = Mathf.Clamp(currentFOV, minFOV, maxFOV);
        playerCamera.fieldOfView = currentFOV;
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

            rotationX += mouseX;
            rotationY -= mouseY;

            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);
        }
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Quaternion horizontalRotation = Quaternion.Euler(0, rotationX, 0);

            Vector3 movement = (horizontalRotation * Vector3.forward * moveVertical +
                               horizontalRotation * Vector3.right * moveHorizontal).normalized;

            movement.y = 0;

            rb.linearVelocity = movement * movementSpeed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void HandleZoom()
    {
        if (!zoomEnabled || playerCamera == null) return;

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            currentFOV -= scrollInput * zoomSpeed;
            currentFOV = Mathf.Clamp(currentFOV, minFOV, maxFOV);
            playerCamera.fieldOfView = currentFOV;
        }
    }
}