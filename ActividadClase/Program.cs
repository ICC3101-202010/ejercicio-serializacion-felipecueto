using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Xml.Serialization;

namespace ActividadClase
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Person person = new Person();
            Stream stream = File.Open("PersonData.dat",FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, person);
            stream.Close();
            stream = File.Open("PersonData.dat", FileMode.Open);
            binaryFormatter = new BinaryFormatter();
            person = (Person)binaryFormatter.Deserialize(stream);
            stream.Close();

            string[] options = { "Agregar Persona", "Guardar y Cargar", "Ver Personas", "Salir" };
            bool selectingMenu = true;
            ConsoleKeyInfo selectedOption;
            while (selectingMenu)
            {
                Console.Clear();
                int optionIndex = 1;
                foreach (string option in options)
                {
                    Console.WriteLine($"{optionIndex} - {option}");

                    optionIndex += 1;
                }
                selectedOption = Console.ReadKey();
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                switch (selectedOption.Key.ToString())
                {
                    case "D1":
                        Console.WriteLine("Agregar Persona");
                        person.AddPerson();
                        break;
                    case "D2":
                        Console.WriteLine("Almacenar y Cargar");
                        
                        break;
                    case "D3":
                        Console.WriteLine("Lista de personas");
                        person.SeePersons();
                        Console.ReadKey();
                        break;
                    case "D4":
                        selectingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Ingrese option valida...");
                        System.Threading.Thread.Sleep(900);
                        break;



                }
            }
        }
    }
}
