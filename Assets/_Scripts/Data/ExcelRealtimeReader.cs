using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExcelDataReader;
using System.Data;
using System.IO;
using System;

public class ExcelRealtimeReader : MonoBehaviour
{
    [SerializeField] private string filePath; //  Path of the Excel file
    [SerializeField] private string sheetName; // Name of the sheet to read
    [SerializeField] private string heavy; // Weight comparison string "AĞIR"

    // Reader, dataset and stream for reading and processing excel file
    private FileStream stream;
    private IExcelDataReader reader;
    private DataSet dataSet;

    // Object creating class
    private CreateObjects createObjects;

    // List to save read objects 
    public List<Item> items = new List<Item>();

    private void Start()
    {
        filePath = Application.dataPath + "/Resources/SampleDataSet.xlsx";
        // Excel files last modification time
        lastModifiedTime = File.GetLastWriteTime(filePath);

        // Custom method to read excel file
        ReadExcelData();

        // Starts checking for file change
        StartCoroutine(PollExcelFile());

    }

    private void ReadExcelData()
    {
        // Open the Excel file and create a reader
        stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        // Read the contents of the specified sheet into a DataSet
        dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
        {
            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
        });

        // Close the reader and the stream
        reader.Close();
        stream.Close();

        // Add the contents of the sheet to the table
        DataTable table = dataSet.Tables[sheetName];
        for (int i = 0; i < table.Rows.Count; i++)
        {
            // Creating a new Item and assigning sheet values to it
            Item temp = new Item();
            temp.shelfAddress = table.Rows[i][0].ToString();
            int.TryParse(table.Rows[i][1].ToString(), out temp.expDate);
            temp.content = table.Rows[i][2].ToString();
            temp.isHeavy = String.CompareOrdinal(heavy, table.Rows[i][3].ToString()) == 0;

            // Adds item to list
            items.Add(temp);

        }
        // Creates objects in list
        createObjects = GameObject.FindObjectOfType<CreateObjects>();
        createObjects.Create(items);
    }

    [SerializeField] private float pollingInterval = 1.0f; // Set this to the interval at which to check for changes, in seconds
    private DateTime lastModifiedTime;

    // Checking if file is modified, calling read data if so
    private IEnumerator PollExcelFile()
    {
        while (true)
        {
            Helper.GetWait(pollingInterval);

            var currentModifiedTime = File.GetLastWriteTime(filePath);
            if (currentModifiedTime > lastModifiedTime)
            {
                lastModifiedTime = currentModifiedTime;
                ReadExcelData();
            }
        }
    }


    private void OnDestroy()
    {
        // Making sure to close the reader and the stream when the script is destroyed
        if (reader != null)
        {
            reader.Close();
        }
        if (stream != null)
        {
            stream.Close();
        }
    }
}
