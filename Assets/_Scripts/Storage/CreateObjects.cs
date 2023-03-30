using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform target;
    public List<Item> objects;
    public List<GameObject> insObjects;
    List<Vector3> positions = new List<Vector3>();
    Vector3 pos;
    public void Create(List<Item> lsItem)
    {
        objects = lsItem;
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject obj = Instantiate(prefab, target.position + Positions()[i], Quaternion.identity);
            ItemInfo info = obj.AddComponent<ItemInfo>();
            info.Address = objects[i].shelfAddress;
            info.ExpDate = objects[i].expDate;
            info.Content = objects[i].content;
            info.isHeavy = objects[i].isHeavy;
            insObjects.Add(obj);
        }
        PlaceObjects place = GameObject.FindObjectOfType<PlaceObjects>();
        place.Place();
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
