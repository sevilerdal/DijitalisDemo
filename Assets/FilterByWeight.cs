using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterByWeight : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    List<GameObject> _heavy = new List<GameObject>();
    List<GameObject> _light = new List<GameObject>();
    public bool wghtFilterOn;
    private ItemList itemIns;
    private void Awake()
    {
        itemIns = ItemList.Instance;
    }
    private void FilterWght()
    {
        wghtFilterOn = true;
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
        // Getting instance of filter
        var filter = GlowFilter.Instance;
        // Filtering heavy items with red
        filter.GlowOn(Color.red, _heavy);
        // Filtering light items with blue
        filter.GlowOn(Color.blue, _light);
    }
    private void CloseGlow()
    {
        wghtFilterOn = false;
        // Getting instance of filter
        var filter = GlowFilter.Instance;
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
        if (wghtFilterOn)
        {
            CloseGlow();
        }
        else
        {
            FilterWght();
        }
    }
}
