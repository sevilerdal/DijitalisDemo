using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterManager : Singleton<FilterManager>
{
    public FilterState state;
    public static event Action<FilterState> OnFilterChanged;

    private void OnEnable()
    {
        UpdateFilterState(FilterState.NoFilter);
    }

    public void UpdateFilterState(FilterState newState)
    {
        state = newState;

        if (state == FilterState.NoFilter)
        {   // Turning off filter for all objects
            SetFilter.Instance.FilterOff(ItemList.Instance.Items);
        }

        // Sends event to subscribed objects
        OnFilterChanged?.Invoke(state);
        Debug.Log($"Filter : {state} state");
    }
}

public enum FilterState
{
    NoFilter,
    ExpirationFilter,
    ContentFilter,
    WeightFilter
}
