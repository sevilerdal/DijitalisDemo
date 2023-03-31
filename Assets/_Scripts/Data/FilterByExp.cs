using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FilterByExp : MonoBehaviour
{

    List<GameObject> items = new List<GameObject>();
    List<GameObject> more = new List<GameObject>();
    List<GameObject> less = new List<GameObject>();
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
    public void FilterExp()
    {
        filter.expFilOn = true;
        ClearLists();
        foreach (var item in itemIns.Items)
        {
            // Checking for items with more days to expire
            if (item.GetComponent<ItemInfo>().ExpDate > 30)
            {
                // Adds to "more" list
                more.Add(item);
            }
            else if (item.GetComponent<ItemInfo>().ExpDate <= 30) // Items with less days to expire
            {
                // Adds to "less" list
                less.Add(item);
            }
        }
        SetGlow();
    }

    private void SetGlow()
    {
        // Filtering items of more days to exp with green
        filter.GlowOn(Color.green, more);
        key1.text = "> 30 days";
        clr1.color = Color.green;
        // Filtering items of less days to exp with red
        filter.GlowOn(Color.red, less);
        key2.text = "<= 30 days";
        clr2.color = Color.red;
    }
    private void CloseGlow()
    {
        filter.expFilOn = false;
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
        if (filter.expFilOn)
        {
            CloseGlow();
        }
        else
        {
            FilterExp();
        }
    }

}
