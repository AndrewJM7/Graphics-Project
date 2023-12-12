using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float regularMovementSpeed = 10f;
    public float boostedMovementSpeed = 20f;
    public float rotationSpeed = 2f;

    private Transform parentTransform;  // Reference to the parent empty object's transform

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Assuming the parent object is the immediate parent of the camera
        parentTransform = transform.parent;
    }

    void Update()
    {
        // Camera Movement
        MoveCamera();

        // Camera Rotation
        RotateCamera();
    }

    void MoveCamera()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Check if Shift is held down for a speed boost
        float currentMovementSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)
            ? boostedMovementSpeed
            : regularMovementSpeed;

        Vector3 movement = new Vector3(horizontal, 0, vertical) * currentMovementSpeed * Time.deltaTime;
        // Apply the movement to the parent object's transform
        parentTransform.Translate(movement);
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed;
        // Apply the rotation to the parent object's transform
        parentTransform.Rotate(rotation);

        // Ensure rotation around z-axis is always zero
        parentTransform.eulerAngles = new Vector3(parentTransform.eulerAngles.x, parentTransform.eulerAngles.y, 0);
    }
}