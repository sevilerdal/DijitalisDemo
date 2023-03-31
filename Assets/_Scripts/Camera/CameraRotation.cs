using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float sensitivity = 5f;

    private bool isRotating = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Check if right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }
        // Check if right mouse button is released
        else if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        // Rotate camera if right mouse button is pressed and dragged
        if (isRotating)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 deltaMousePosition = currentMousePosition - lastMousePosition;

            transform.RotateAround(transform.position, Vector3.up, deltaMousePosition.x * sensitivity);
            transform.RotateAround(transform.position, transform.right, -deltaMousePosition.y * sensitivity);

            lastMousePosition = currentMousePosition;
        }
    }
}
