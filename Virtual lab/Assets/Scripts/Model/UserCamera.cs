using UnityEngine;

public class UserCamera : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10; 
    [SerializeField] private float lookSensitivity = 2; 

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
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");     

        Vector3 movement = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized;
        movement.y = 0; 

        rb.linearVelocity = movement * movementSpeed;

        if (Input.GetMouseButton(1)) 
        {
            rotationX += Input.GetAxis("Mouse X") * lookSensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * lookSensitivity;

            rotationY = Mathf.Clamp(rotationY, -90f, 90f);

            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);

        }
    }
}
