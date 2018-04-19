using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mail
{
    class Tools
    {
        public Dictionary<string,string> JsonToDictionary(string path) {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            StreamReader stream = new StreamReader(path);
            string jsonString = stream.ReadToEnd();
            dictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            
            return dictionary;
        }
    }
}
