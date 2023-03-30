using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform target;
    public List<Item> objects;
    List<Vector3> positions = new List<Vector3>();
    ItemList itemIns;
    private void Awake()
    {
        itemIns = ItemList.Instance;
    }
    public void Create(List<Item> lsItem)
    {
        objects = lsItem;
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject obj = Instantiate(prefab, target.position + Positions()[i], Quaternion.identity);
            ConfigureObject(obj, objects[i]);
        }
        PlaceObjects place = GameObject.FindObjectOfType<PlaceObjects>();
        place.Place();
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
    private List<Vector3> Positions()
    {
        positions.Clear();
        Vector3 temp;
        for (int i = 0; i < objects.Count / 3; i++)
        {
            for (int j = 0; j < objects.Count / 3; j++)
            {
                for (int k = 0; k < objects.Count / 3; k++)
                {
                    temp.y = i * 1.75f;
                    temp.x = j * 1.75f;
                    temp.z = k * 1.75f;
                    positions.Add(temp);
                }
            }
        }

        return positions;
    }
}
