using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//using System.xml.Serialatation;

namespace ActividadClase
{
    [Serializable()]
    public class Person:ISerializable
    {
        //List<Person> persons = new List<Person>();
        private Dictionary<int, List<string>> persons;
        private string name;
        private string lastName;
        private string age;

        public Person()
        {
        }
        public void AddPerson()
        {
            Console.Write("Nombre:");
            name = Console.ReadLine();
            Console.Write("Apellido:");
            lastName = Console.ReadLine();
            Console.Write("Edad:");
            age = Console.ReadLine();
            AddPerson(new List<string>(){ name, lastName, age});
        }

        public void AddPerson(List<string> data)
        {
                this.persons.Add(persons.Count + 1, data);
        }

        public void SeePersons()
        {
            foreach (List<string> user in this.persons.Values)
            {
                Console.WriteLine(user);
            }

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("LastName", lastName);
            info.AddValue("Age", age);

        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            name = (string)info.GetValue("Name", typeof(string));
            name = (string)info.GetValue("LastName", typeof(string));
            name = (string)info.GetValue("Age", typeof(string));

        }

    }
}
