using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 movement, currentV;
    Rigidbody rb;
    [SerializeField] private float movementSpeed, maxSpeed, smoothTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveVertical(1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveHorizontal(-1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveVertical(-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveHorizontal(1);
        }
    }

    private void MoveHorizontal(int way)
    {

        movement = Vector3.SmoothDamp(movement, Vector3.right * way, ref currentV, smoothTime, maxSpeed);
        rb.AddForce(movement * movementSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    private void MoveVertical(int way)
    {

        movement = Vector3.SmoothDamp(movement, Vector3.forward * way, ref currentV, smoothTime, maxSpeed);
        rb.AddForce(movement * movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }
}
