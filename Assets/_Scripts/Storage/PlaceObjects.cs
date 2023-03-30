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
        var obj = create.insObjects;

        for (int i = 0; i < obj.Count; i++)
        {
            var target = GameObject.Find(create.insObjects[i].GetComponent<ItemInfo>().Address.ToString());

            if (target == null)
            {
                Debug.Log("target not found");
                break;
            }

            if (target != null)
            {
                targetPos = target.transform.position;
                targetPos.y += 1.2f;
                create.insObjects[i].transform.position = targetPos;
            }
        }
    }
}
