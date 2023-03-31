using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FilterByWeight : FilterBase
{
    public void FilterWght()
    {
        ClearLists();
        foreach (var item in itemIns.Items)
        {
            // Checking for heavy items
            if (item.GetComponent<ItemInfo>().isHeavy)
            {
                // Adds to "heavy" list
                set1.Add(item);
            }
            else if (!item.GetComponent<ItemInfo>().isHeavy) // Light items
            {
                // Adds to "light" list
                set2.Add(item);
            }
        }
        TurnFOn(Color.red, set1, Color.blue, set2);
    }

    protected override void FilterChange(FilterState state)
    {
        if (state == FilterState.WeightFilter)
        {
            FilterWght();
        }
    }

}
