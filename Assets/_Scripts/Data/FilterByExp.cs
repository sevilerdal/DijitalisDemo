using UnityEngine;

public class FilterByExp : FilterBase
{
    public void FilterExp()
    {
        ClearLists();
        foreach (var item in itemIns.Items)
        {
            // Checking for items with more days to expire
            if (item.GetComponent<ItemInfo>().ExpDate > 30)
            {
                // Adds to "more" list
                set1.Add(item);
            }
            else if (item.GetComponent<ItemInfo>().ExpDate <= 30) // Items with less days to expire
            {
                // Adds to "less" list
                set2.Add(item);
            }
        }
        // Calls turn on method from base
        TurnFOn(Color.green, set1, Color.red, set2);
    }

    protected override void FilterChange(FilterState state)
    {
        if (state == FilterState.ExpirationFilter)
        {
            FilterExp();
        }
    }




}
