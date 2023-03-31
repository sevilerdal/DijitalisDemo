using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Variables to change movement speed and limit
    [SerializeField] private float movementSpeed, minX, minZ, maxX, maxZ;

    private void Update()
    {

        // get input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // calculate movement vector based on input and camera rotation
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f) * movement;
        Vector3 newPosition = transform.position + movement * movementSpeed * Time.deltaTime;
        // limit camera position
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
        // apply movement to camera position
        transform.position = newPosition;
    }

}
