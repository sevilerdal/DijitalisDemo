using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFilters : MonoBehaviour
{
    FilterManager fManager;
    private void Start()
    {
        if (fManager == null)
            fManager = FilterManager.Instance;
    }
    public void FiltersOff()
    {
        if (fManager.state != FilterState.NoFilter)
        {
            fManager.UpdateFilterState(FilterState.NoFilter);
        }
    }
    public void ExpirationFilter()
    {
        if (fManager.state != FilterState.ExpirationFilter)
        {
            fManager.UpdateFilterState(FilterState.ExpirationFilter);
        }
        else
        {
            FiltersOff();
        }
    }
    public void ContentFilter()
    {
        if (fManager.state != FilterState.ContentFilter)
        {
            fManager.UpdateFilterState(FilterState.ContentFilter);
        }
        else
        {
            FiltersOff();
        }
    }
    public void WeightFilter()
    {
        if (fManager.state != FilterState.WeightFilter)
        {
            fManager.UpdateFilterState(FilterState.WeightFilter);
        }
        else
        {
            FiltersOff();
        }
    }
}
