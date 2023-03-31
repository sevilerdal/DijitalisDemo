using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyUIControl : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI key, key2;
    [SerializeField] private Image img, img2;
    [SerializeField] private Color _red, _green, _blue, _yellow;
    private void OnEnable()
    {
        // Subscribe to filter change event
        FilterManager.OnFilterChanged += FilterChange;
    }
    private void OnDisable()
    {
        // Unsubscribe to filter change event
        FilterManager.OnFilterChanged -= FilterChange;
    }

    private void FilterChange(FilterState state)
    {
        switch (state)
        {
            // Panel is hidden while no filter is active
            case FilterState.NoFilter:
                panel.SetActive(false);
                break;

            // Sets color values for each filter
            case FilterState.ExpirationFilter:
                panel.SetActive(true);
                SetKey("30 günden fazla", _green, "30 ve daha az", _red);
                break;

            case FilterState.ContentFilter:
                panel.SetActive(true);
                SetKey("Yiyecek", _green, "İçecek", _yellow);
                break;

            case FilterState.WeightFilter:
                panel.SetActive(true);
                SetKey("Ağır", _red, "Hafif", _blue);
                break;

            // Panel is hidden in any other case
            default:
                panel.SetActive(false);
                break;
        }
    }

    // Custom method to assign text and colors to UI elements
    private void SetKey(string txt, Color clr, string txt2, Color clr2)
    {
        key.text = txt;
        key2.text = txt2;
        img.color = clr;
        img2.color = clr2;

    }
}
