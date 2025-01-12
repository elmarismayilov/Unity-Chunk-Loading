using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    public GameObject player;
    private float rotationLimit = 80f;

    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // Calculate vertical rotation with clamping
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -rotationLimit, rotationLimit);
        
        // Apply vertical rotation to camera only
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        
        // Update camera position to follow player
        transform.position = new Vector3(player.transform.position.x, 
            player.transform.position.y + 0.6f, 
            player.transform.position.z);
    }
}