using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FilterBase : MonoBehaviour
{
    protected List<GameObject> items = new List<GameObject>();
    protected List<GameObject> set1 = new List<GameObject>();
    protected List<GameObject> set2 = new List<GameObject>();
    protected ItemList itemIns;
    protected SetFilter filter;
    [SerializeField] private TextMeshProUGUI key1, key2;
    [SerializeField] private Image clr1, clr2;

    protected virtual void OnEnable()
    {
        FilterManager.OnFilterChanged += FilterChange;
    }
    protected virtual void OnDisable()
    {
        FilterManager.OnFilterChanged -= FilterChange;
    }
    protected virtual void Start()
    {
        // Getting instances
        itemIns = ItemList.Instance;
        filter = SetFilter.Instance;
    }

    protected virtual void FilterChange(FilterState state)
    {

    }

    protected virtual void ClearLists()
    {
        set1.Clear();
        set2.Clear();
        items.Clear();
    }

    protected virtual void TurnFOn(Color clr1, List<GameObject> ls1,
                                     Color clr2, List<GameObject> ls2)
    {
        filter.FilterOn(clr1, ls1);
        filter.FilterOn(clr2, ls2);
    }



}
