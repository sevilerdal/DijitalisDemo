using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    [SerializeField] private RectTransform boxTransform;
    [SerializeField] private Canvas canvas;

    private void Update()
    {
        // Get the position of the mouse in screen space
        Vector2 mousePosition = Input.mousePosition;

        // Convert the screen space position to canvas space position
        Vector2 canvasPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.worldCamera, out canvasPosition);
        // Calculate the offset to position the top left corner of the box nearest to the cursor
        Vector2 offset = new Vector2(-boxTransform.rect.width / 2f, boxTransform.rect.height / 2f);

        // Set the position of the cursor image to the canvas space position
        boxTransform.localPosition = canvasPosition - offset;
    }
}
