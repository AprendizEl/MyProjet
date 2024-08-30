using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using System.Threading.Tasks;

namespace TheProject.Models
{
    public class Tools
    {
        public void SaveToBinaryFile<T>(List<T> data, string filePath)
        {
            var serializer = new DataContractSerializer(typeof(List<T>));
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                serializer.WriteObject(stream, data);
            }
        }

        public List<T> LoadFromBinaryFile<T>(string filePath)
        {
            var serializer = new DataContractSerializer(typeof(List<T>));
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return (List<T>)serializer.ReadObject(stream);
            }
        }



    }
}
