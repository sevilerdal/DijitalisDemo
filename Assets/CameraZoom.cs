using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 10f; // adjust this to control zoom speed
    [SerializeField] private float minZoom = 1f; // minimum zoom distance
    [SerializeField] private float maxZoom = 10f; // maximum zoom distance

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // get mouse wheel input
        float fov = Camera.main.fieldOfView; // get current field of view

        // apply zoom
        if (scroll != 0)
        {
            fov -= scroll * zoomSpeed;
            fov = Mathf.Clamp(fov, minZoom, maxZoom); // ensure field of view stays within min/max bounds
            Camera.main.fieldOfView = fov; // set new field of view based on zoom level
        }
    }
}
