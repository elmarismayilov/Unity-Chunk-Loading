using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    
    private float horizontalInput;
    private float verticalInput;
    private float mouseX;
    
    public bool isGrounded;
    public Rigidbody rb;
    public float jumpForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get movement input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Get mouse input for horizontal rotation
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        
        // Rotate the player based on mouse X movement
        transform.Rotate(Vector3.up * mouseX);
        
        // Calculate movement direction relative to player rotation
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        // Normalize movement if magnitude > 1
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
        // Apply movement
        transform.Translate(moveDirection * (movementSpeed * Time.deltaTime), Space.World);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}