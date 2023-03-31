using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FilterByContent : MonoBehaviour
{
    [SerializeField] private string foodStr, drinkStr;
    List<GameObject> items = new List<GameObject>();
    List<GameObject> food = new List<GameObject>();
    List<GameObject> drink = new List<GameObject>();
    public bool contFilterOn;
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
    public void FilterCon()
    {
        filter.conFilOn = true;
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
        // Filtering food items with green
        filter.GlowOn(Color.green, food);
        key1.text = "Food";
        clr1.color = Color.green;
        // Filtering drink items with yellow
        filter.GlowOn(Color.yellow, drink);
        key2.text = "Drink";
        clr2.color = Color.yellow;
    }
    private void CloseGlow()
    {
        filter.conFilOn = false;
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
        if (filter.conFilOn)
        {
            CloseGlow();
        }
        else
        {
            FilterCon();
        }
    }
}
