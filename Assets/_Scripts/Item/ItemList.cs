using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : Singleton<ItemList>
{
    protected override void Awake()
    {
        base.Awake();
        Items.Clear();
    }

    public void AddToList(GameObject item)
    {
        Items.Add(item);
    }

    public List<GameObject> Items = new List<GameObject>();

}
