using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterByExp : MonoBehaviour
{

    List<GameObject> items = new List<GameObject>();
    List<GameObject> more = new List<GameObject>();
    List<GameObject> less = new List<GameObject>();
    private bool isOn;
    private ItemList itemIns;
    private void Awake()
    {
        itemIns = ItemList.Instance;
    }
    private void FilterExp()
    {
        isOn = true;
        ClearLists();
        foreach (var item in itemIns.Items)
        {
            // Checking for items with more days to expire
            if (item.GetComponent<ItemInfo>().ExpDate > 30)
            {
                // Adds to "more" list
                more.Add(item);
            }
            else // Items with less days to expire
            {
                // Adds to "less" list
                less.Add(item);
            }
        }

        SetGlow();
    }

    private void SetGlow()
    {
        Debug.Log("setglow");
        Debug.Log($"more : {more.Count}");
        Debug.Log($"less : {less.Count}");
        // Getting instance of filter
        var filter = GlowFilter.Instance;
        // Filtering items of more days to exp with green
        filter.GlowOn(Color.green, more);
        // Filtering items of less days to exp with red
        filter.GlowOn(Color.red, less);
    }
    private void CloseGlow()
    {
        isOn = false;
        // Getting instance of filter
        var filter = GlowFilter.Instance;
        // Turning off filters - items of more days to exp
        filter.GlowOff(more);
        // Turning off filters - items of less days to exp 
        filter.GlowOff(less);
    }

    private void ClearLists()
    {
        // Clearing lists to prevent overriding previous filters
        more.Clear();
        less.Clear();
        items.Clear();
    }

    public void ToggleFilter()
    {
        if (isOn)
        {
            CloseGlow();
        }
        else
        {
            Debug.Log("Should filter");
            FilterExp();
        }
    }

}
