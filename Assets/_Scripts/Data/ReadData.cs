using System;
using System.Collections.Generic;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    [SerializeField] private string heavy;
    CreateObjects createObjects;
    List<Item> tempItems = new List<Item>();
    private void Start()
    {
        ReadFile();
    }
    [SerializeField] private TextAsset inputFile;

    public void ReadFile()
    {
        string[] data = inputFile.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        for (int i = 1; i < data.Length / 4; i++)
        {
            Item temp = new Item();
            temp.shelfAddress = data[i * 4];
            int.TryParse(data[i * 4 + 1].ToString(), out temp.expDate);
            temp.content = data[i * 4 + 2];
            temp.isHeavy = CompareString(heavy, data[i * 4 + 3].ToString());
            tempItems.Add(temp);
        }
        createObjects = GameObject.FindObjectOfType<CreateObjects>();
        createObjects.Create(tempItems);
    }

    private bool CompareString(string a, string b)
    {
        char[] first = a.ToCharArray();
        char[] second = b.ToCharArray();
        bool isEqual = false;
        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] == second[i])
            {
                isEqual = true;
            }
            else
            {
                isEqual = false;
                break;
            }
        }
        return isEqual;
    }

}
