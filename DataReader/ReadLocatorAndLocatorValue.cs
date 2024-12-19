using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;

namespace Spaidy.DataReader
{
    public class ReadLocatorAndLocatorValue
    {
        public String value1;
        public String value2;

        public By ReadFromCSV1(String Name1, string FilePath)
        {
            string[] data = GetCsvData(FilePath);
            Record[] records = ParseCsvData(data);

            foreach (Record record in records)
            {
                if (record.Name == Name1)
                {
                    value1 = record.Locator;
                    value2 = record.LocatorValue;
                }
            }
            return GetElementLocator(value1, value2);

        }
        private By GetElementLocator(string Locator, string LocatorValue)
        {
            switch (Locator)
            {
                case "ClassName":
                    return By.ClassName(LocatorValue);
                case "CssSelector":
                    return By.CssSelector(LocatorValue);
                case "Id":
                    return By.Id(LocatorValue);
                case "PartialLinkText":
                    return By.PartialLinkText(LocatorValue);
                case "Name":
                    return By.Name(LocatorValue);
                case "XPath":
                    return By.XPath(LocatorValue);
                case "TagName":
                    return By.TagName(LocatorValue);
                default:
                    return By.Id(LocatorValue);
            }
        }
        public static string[] GetCsvData(string filePath)
        {
            //const string filePath = @"C:\Users\Admin\Documents\Visual Studio 2013\ExpectedValue.csv";
            string[] data = File.ReadAllLines(filePath);
            return data;
        }
        public static Record[] ParseCsvData(string[] data)
        {
            List<Record> list = new List<Record>();
            //start loop at index = 1, since we want to skip the header data.
            for (int i = 1; i < data.Length; i++)
            {
                string line = data[i];
                string[] tokens = line.Split(',');
                String name = tokens[0];
                String value1 = tokens[1];
                String value2 = tokens[2];
                list.Add(new Record(name, value1, value2));
            }
            return list.ToArray();
        }
    }

    public class Record
    {
        public String Name { get; set; }
        public String Locator { get; set; }
        public String LocatorValue { get; set; }

        public Record(String name, String value1, String value2)
        {
            Name = name;
            Locator = value1;
            LocatorValue = value2;
        }
    }
}

