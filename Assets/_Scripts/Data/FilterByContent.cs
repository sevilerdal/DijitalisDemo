using UnityEngine;

public class FilterByContent : FilterBase
{
    [SerializeField] private string food, drink;
    public void FilterCon()
    {
        ClearLists();
        foreach (var item in itemIns.Items)
        {
            // Checking for items type: food
            if (item.GetComponent<ItemInfo>().Content == food)
            {
                // Adds to "food" list
                set1.Add(item);
            }
            else if (item.GetComponent<ItemInfo>().Content == drink) // Items, type : drinks
            {
                // Adds to "drink" list
                set2.Add(item);
            }
        }
        // Custom method to turn filter on
        TurnFOn(Color.green, set1, Color.yellow, set2);
    }

    protected override void FilterChange(FilterState state)
    {
        // Checking if content filter should be on
        if (state == FilterState.ContentFilter)
        {
            FilterCon();
        }
    }
}
