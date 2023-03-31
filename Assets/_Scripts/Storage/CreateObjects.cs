using System.Collections.Generic;
using UnityEngine;
public class CreateObjects : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public List<Item> objects;
    List<Vector3> positions = new List<Vector3>();
    [SerializeField] private ItemList itemIns;
    Vector3 offset = new Vector3(0, 1.2f, 0);

    public void Create(List<Item> lsItem)
    {
        // Takes passed list
        objects = lsItem;

        // Iterates every member of list
        for (int i = 0; i < objects.Count; i++)
        {
            // Creates a gameobject for every item on list
            GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            ConfigureObject(obj, objects[i]);
            // Places object to appropriate shelf
            obj.transform.position = GameObject.Find(obj.GetComponent<ItemInfo>().Address.ToString()).transform.position + offset;
        }
    }
    private void ConfigureObject(GameObject obj, Item item)
    {
        ItemInfo info = obj.AddComponent<ItemInfo>();
        info.Address = item.shelfAddress;
        info.ExpDate = item.expDate;
        info.Content = item.content;
        info.isHeavy = item.isHeavy;
        itemIns.AddToList(obj);
    }
}
