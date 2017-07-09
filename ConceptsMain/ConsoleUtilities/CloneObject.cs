using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUtilities
{
    class CloneObject
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                ID = 1,
                Name = "Vaibhav Agarwal",
                Address = new Address
                {
                    Line1 = "Address Line 1",
                    Line2 = "Address Line 2",
                    State = new State
                    {
                        StateID = 1,
                        Name = "Haryana",
                        Cities = new List<Cities>
                                            {
                                               new Cities { CityID = 1, CityName = "Faridabad" },
                                               new Cities { CityID = 2, CityName = "Gurgaon" }
                                            }
                    }
                }


            };

            Person p2 = DeepClone<Person>(p);

            p2.Name = "Garima";
            p2.Address.State.StateID = 2;
            p2.Address.State.Name = "Tamil Nadu";
            p2.Address.State.Cities = new List<Cities> { new Cities { CityID = 1, CityName = "Chennai" } };

            Console.WriteLine("Object Name from p " + p.Name);
            Console.WriteLine("Object Name from p2 " + p2.Name);
            Console.ReadLine();

        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

    }

    [Serializable]
    class Person
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }


    }
    [Serializable]
    class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public State State { get; set; }
    }

    [Serializable]
    class State
    {
        public int StateID { get; set; }
        public string Name { get; set; }
        public List<Cities> Cities { get; set; }
        public State()
        {
            Cities = new List<Cities>();
        }

    }

    [Serializable]
    public class Cities
    {
        public int CityID { get; set; }
        public string CityName { get; set; }

    }
}

