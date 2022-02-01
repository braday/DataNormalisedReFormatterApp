using CsvHelper;
using CsvHelper.Configuration;
using DataNormalisedReFormatter.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DataNormalisedReFormatter
{
    public class DataReader
    {
        private List<InputDataModel> inputData;
        private List<OutputDataModel> outputData;

        public void ReadData(string filePath)
        {
            // read file use csvhelper
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<InputDataModel>();
                inputData = records.ToList();

                foreach (var record in inputData)
                {
                    Console.WriteLine(record.Email);
                }
            }
        }

        public void ProcessData()
        {
            outputData = new List<OutputDataModel>();

            var i = 0;

            foreach (var record in inputData)
            {

                // split the data in the last column
                String[] spearator = { "," };
                string[] dataList = record.Email.Split(spearator, StringSplitOptions.RemoveEmptyEntries);


                if (record.Email.Contains(","))
                {

                    foreach (var row in dataList)
                    {
                        i += 1;
                        var newRecord = new OutputDataModel()
                        {
                            ID = i,
                            LastName = record.LastName,
                            FirstName = record.FirstName,
                            MiddleName = record.MiddleName,
                            PreferredName = record.PreferredName,
                            Address = record.Address.Replace(",", "@"),
                            Email = row.Trim(),
                            Phone = record.Phone,
                            Mobile = record.Mobile.Replace(",", "@"),
                            CategoryNumber = record.CategoryNumber,
                            Cateogry = record.Cateogry,
                            Method = record.Method
                        };
                        outputData.Add(newRecord);

                        Console.WriteLine(@$"{i} - multi email are {record.Email}");
                    }
                }
                else
                {
                    i += 1;
                    var newRecord = new OutputDataModel()
                    {
                        ID = i,
                        LastName = record.LastName,
                        FirstName = record.FirstName,
                        MiddleName = record.MiddleName,
                        PreferredName = record.PreferredName,
                        Address = record.Address.Replace(",", "@"),
                        Email = record.Email,
                        Phone = record.Phone,
                        Mobile = record.Mobile.Replace(",", "@"),
                        CategoryNumber = record.CategoryNumber,
                        Cateogry = record.Cateogry,
                        Method = record.Method,
                        LDCID = i
                        
                    };

                    outputData.Add(newRecord);
                    Console.WriteLine(@$"{i} - single email is {record.Email}");
                }
            }
            Console.WriteLine("Total: " + outputData.Count());
        }

        public void WriteData(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Mode = CsvMode.NoEscape
            };

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteHeader<OutputDataModel>();
                csv.NextRecord();
                foreach (var record in outputData)
                {
                    csv.WriteRecord(record);
                    csv.NextRecord();
                }
            }
        }

        // remove all html tags from a string
        //public string RemoveHtmlTag(string input)
        //{
        //    return Regex.Replace(input, "<.*?>", String.Empty);
        //}
    }
}