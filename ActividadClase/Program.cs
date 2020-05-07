using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ActividadClase
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            try
            {
                FileStream FS = new FileStream("Persons.txt", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                persons = (List<Person>)binaryFormatter.Deserialize(FS);
                FS.Close();
            }
            catch
            {
                Console.WriteLine("No se puedo gauardar los dados");
            }

            Console.WriteLine("Agenda de personas");
            string[] options = { "Agregar Persona", "Guardar", "Ver Personas", "Salir" };
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
                        Console.Write("Nombre:");
                        string name = Console.ReadLine();
                        Console.Write("Apellido:");
                        string lastName = Console.ReadLine();
                        Console.Write("Edad:");
                        string age = Console.ReadLine();
                        Person person = new Person(name, lastName, age);
                        persons.Add(person);
                        break;
                    case "D2":
                        {
                            Console.WriteLine("Guardar");
                            FileStream FS1 = new FileStream("Persons.txt", FileMode.Create);
                            BinaryFormatter binaryFormatter = new BinaryFormatter();
                            try
                            {
                                binaryFormatter.Serialize(FS1, persons);
                                FS1.Flush();
                                FS1.Close();
                                Console.WriteLine("Se guardaron los dados");
                                System.Threading.Thread.Sleep(900);
                            }
                            catch
                            {
                                Console.WriteLine("No se puedo gauardar los dados");
                                System.Threading.Thread.Sleep(900);
                            }
                        }

                        break;
                    case "D3":
                        Console.WriteLine("Lista de personas:");
                        foreach (Person person1 in persons)
                        {
                            Console.WriteLine(person1.Name);
                            Console.WriteLine(person1.LastName);
                            Console.WriteLine(person1.Age+"\n");
                            System.Threading.Thread.Sleep(900);
                        }
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
