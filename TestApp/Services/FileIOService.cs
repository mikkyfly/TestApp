using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using TestApp.Models;

namespace TestApp.Services
{
    class FileIOService
    {
        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<Model> LoadData()
        {
            var fileExists= File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Model>();
            }
            using (var reader= File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Model>>(fileText);
            }
        }
        public void SaveData(object dataList)
        {
            using (StreamWriter write = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(dataList);
                write.WriteLine(output); 
            }
                
        }
    }
}
