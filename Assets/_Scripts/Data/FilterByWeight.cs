using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FilterByWeight : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    List<GameObject> _heavy = new List<GameObject>();
    List<GameObject> _light = new List<GameObject>();
    private ItemList itemIns;
    private GlowFilter filter;
    [SerializeField] private TextMeshProUGUI key1, key2;
    [SerializeField] private Image clr1, clr2;
    private void Start()
    {
        itemIns = ItemList.Instance;
        // Getting instance of filter
        filter = GlowFilter.Instance;
    }
    public void FilterWght()
    {
        filter.wghtFilOn = true;
        ClearLists();
        foreach (var item in itemIns.Items)
        {
            // Checking for heavy items
            if (item.GetComponent<ItemInfo>().isHeavy)
            {
                // Adds to "heavy" list
                _heavy.Add(item);
            }
            else if (!item.GetComponent<ItemInfo>().isHeavy) // Light items
            {
                // Adds to "light" list
                _light.Add(item);
            }
        }
        SetGlow();
    }

    private void SetGlow()
    {
        // Filtering heavy items with red
        filter.GlowOn(Color.red, _heavy);
        key1.text = "Heavy";
        clr1.color = Color.red;
        // Filtering light items with blue
        filter.GlowOn(Color.blue, _light);
        key2.text = "Light";
        clr2.color = Color.blue;
    }
    private void CloseGlow()
    {
        filter.wghtFilOn = false;
        // Turning off filters - heavy items 
        filter.GlowOff(_heavy);
        // Turning off filters - light items 
        filter.GlowOff(_light);
    }

    private void ClearLists()
    {
        // Clearing lists to prevent overriding previous filters
        _heavy.Clear();
        _light.Clear();
        items.Clear();
    }

    public void ToggleFilter()
    {
        if (filter.wghtFilOn)
        {
            CloseGlow();
        }
        else
        {
            FilterWght();
        }
    }
}
