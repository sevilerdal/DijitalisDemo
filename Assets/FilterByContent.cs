using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterByContent : MonoBehaviour
{
    [SerializeField] private string foodStr, drinkStr;
    List<GameObject> items = new List<GameObject>();
    List<GameObject> food = new List<GameObject>();
    List<GameObject> drink = new List<GameObject>();
    public bool contFilterOn;
    private ItemList itemIns;
    private void Awake()
    {
        itemIns = ItemList.Instance;
    }
    private void FilterWght()
    {
        contFilterOn = true;
        ClearLists();
        foreach (var item in itemIns.Items)
        {
            // Checking for items type: food
            if (item.GetComponent<ItemInfo>().Content == foodStr)
            {
                // Adds to "food" list
                food.Add(item);
            }
            else if (item.GetComponent<ItemInfo>().Content == drinkStr) // Items, type : drinks
            {
                // Adds to "drink" list
                drink.Add(item);
            }
        }
        SetGlow();
    }

    private void SetGlow()
    {
        // Getting instance of filter
        var filter = GlowFilter.Instance;
        // Filtering food items with green
        filter.GlowOn(Color.green, food);
        // Filtering drink items with yellow
        filter.GlowOn(Color.yellow, drink);
    }
    private void CloseGlow()
    {
        contFilterOn = false;
        // Getting instance of filter
        var filter = GlowFilter.Instance;
        // Turning off filters -food items
        filter.GlowOff(food);
        // Turning off filters - drink items 
        filter.GlowOff(drink);
    }

    private void ClearLists()
    {
        // Clearing lists to prevent overriding previous filters
        food.Clear();
        drink.Clear();
        items.Clear();
    }

    public void ToggleFilter()
    {
        if (contFilterOn)
        {
            CloseGlow();
        }
        else
        {
            FilterWght();
        }
    }
}
