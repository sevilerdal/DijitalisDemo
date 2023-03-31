using System.Collections.Generic;
using UnityEngine;

public class ItemList : Singleton<ItemList>
{
    public List<GameObject> Items = new List<GameObject>();

    [SerializeField] private CreationAnimation creationAnimation;
    protected override void Awake()
    {
        base.Awake();

        // Clearing item list to prevent data confusion
        Items.Clear();
    }

    // Adds passed item to list
    public void AddToList(GameObject item)
    {
        Items.Add(item);

        // Animates new item with glow
        creationAnimation.AnimateObj(item);
    }


}
