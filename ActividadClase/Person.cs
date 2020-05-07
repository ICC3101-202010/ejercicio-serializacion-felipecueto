using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//using System.xml.Serialatation;

namespace ActividadClase
{
    [Serializable()]
    public class Person
    {
        private string name;
        private string lastName;
        private string age;

        public Person(string name,string lastName,string age)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
        }

        public string Name => name;
        public string LastName => lastName;
        public string Age => age;

    }
}
