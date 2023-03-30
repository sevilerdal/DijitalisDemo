using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{
    CreateObjects create;
    Vector3 targetPos;
    public void Place()
    {
        create = GameObject.FindObjectOfType<CreateObjects>();
        var listIns = ItemList.Instance;
        var items = listIns.Items;
        for (int i = 0; i < items.Count; i++)
        {
            var target = GameObject.Find(items[i].GetComponent<ItemInfo>().Address.ToString());

            if (target == null)
            {
                Debug.Log("target not found");
                break;
            }

            if (target != null)
            {
                targetPos = target.transform.position;
                targetPos.y += 1.2f;
                items[i].transform.position = targetPos;
            }
        }
    }
}
