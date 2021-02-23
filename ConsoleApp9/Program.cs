using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp9
{
    class Program
    {
        [Serializable]
        struct Car
        {
            [JsonIgnore]
            public int Year { get; set; }
            [JsonProperty("Model of Car")]
            public string Model { get; set; }
            [JsonRequired]
            public string Vendor { get; set; }
            public override string ToString()
            {
                return $"{Model} - {Vendor} - {Year}";
            }
        }
        static void JsonSerialize()
        {
            List<Car> cars = new List<Car>
                    {
                        new Car
                        {
                            Model = "Mustang",
                            Vendor = "Ford",
                            Year = 2019
                        },
                        new Car
                        {
                            Model = "Jeep",
                            Vendor = "Grand Cherokee",
                            Year = 2014
                        },
                        new Car
                        {
                            Model = "Evo 8",
                            Vendor = "Mitsubishi",
                            Year = 2008
                        },
                        new Car
                        {
                            Model = "Veyron",
                            Vendor = "Bugatti",
                            Year = 2020
                        },
                    };
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("json.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, cars);
                }
            }

        }
        static void DeSerialize()
        {
            
            Car[] cars = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("json.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    cars = serializer.Deserialize<Car[]>(jr);
                }
                foreach (var item in cars)
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void Main(string[] args)
        {
            DeSerialize();
        }
    }
} 



