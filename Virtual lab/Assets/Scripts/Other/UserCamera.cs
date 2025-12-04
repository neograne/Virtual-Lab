using UnityEngine;

public class UserCamera : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float lookSensitivity = 2;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minFOV = 10f;
    [SerializeField] private float maxFOV = 60f;
    [SerializeField] private bool zoomEnabled = true;

    private float currentFOV;
    private Camera cam;

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

    private float rotationX = 0;
    private float rotationY = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        cam = GetComponent<Camera>();
        if (cam != null)
        {
            currentFOV = cam.fieldOfView;
            maxFOV = currentFOV;
        }
    }

    public void SetZoomEnabled(bool enabled)
    {
        zoomEnabled = enabled;
    }

    void Update()
    {
        if (zoomEnabled)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            if (scrollInput != 0 && cam != null)
            {
                currentFOV -= scrollInput * zoomSpeed;
                currentFOV = Mathf.Clamp(currentFOV, minFOV, maxFOV);
                cam.fieldOfView = currentFOV;
            }
        }

        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * lookSensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * lookSensitivity;
            rotationY = Mathf.Clamp(rotationY, -90f, 90f);
            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Vector3 movement = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized;
            movement.y = 0;
            rb.linearVelocity = movement * movementSpeed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}