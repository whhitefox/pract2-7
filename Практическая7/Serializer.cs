using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая7
{
    internal class Serializer
    {
        public static T Load<T>(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                return default(T);
            }
        }
    }
}
