using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InfoPanelControl : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TextMeshProUGUI exp, cont, wght;

    private void Awake()
    {
        // Deactivates panel at launch
        infoPanel.SetActive(false);
    }
    void Update()
    {
        // Deactivates panel if user is moving
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetMouseButtonDown(1) || Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            infoPanel.SetActive(false);
        }

        // Checks what user clicks on 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Helper.Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }

    private void CurrentClickedGameObject(GameObject obj)
    {
        // Checks if clicked item is a box (Item)
        if (obj.CompareTag("Box"))
        {
            UpdateUI(obj);
        }
        else
        {
            infoPanel.SetActive(false);
        }
    }


    private void UpdateUI(GameObject obj)
    {
        // Get iteminfo 
        var info = obj.GetComponent<ItemInfo>();
        if (info == null) return;

        // Assigning UI text values to info from object
        exp.text = info.ExpDate.ToString();
        cont.text = info.Content;
        if (info.isHeavy)
        {
            wght.text = "AĞIR";
        }
        else if (!info.isHeavy)
        {
            wght.text = "HAFİF";
        }

        // Position panel in front of the box
        infoPanel.transform.position = Helper.Camera.WorldToScreenPoint(obj.transform.position);
        // Show panel
        infoPanel.SetActive(true);
    }
}
