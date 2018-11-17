using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAgasha
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person() { ID = 1, Name = "Baba" };
            var formatter = new BinaryFormatter();
            var stream = File.Create("p.person");

            Serialize<Person>(p, formatter, stream);
            var newP = Deserialize<Person>(formatter, File.Open("p.person", FileMode.Open));
        }

        static void Serialize<T>(T objectGraph, IFormatter formatter, Stream stream )
        {
            try
            {
                formatter.Serialize(stream, objectGraph);
                stream.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }

        static T Deserialize<T>(IFormatter formatter, Stream stream)
        {
            try
            {
               var result =  (T)formatter.Deserialize(stream);
                stream.Close();

                return result;

            }
            catch (Exception)
            {
                return default(T);
               
            }
        }

        [Serializable]
        class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}
