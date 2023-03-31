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
        infoPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
        var info = obj.GetComponent<ItemInfo>();
        if (info == null) return;
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
        infoPanel.transform.position = Camera.main.WorldToScreenPoint(obj.transform.position);
        infoPanel.SetActive(true);
    }
}
