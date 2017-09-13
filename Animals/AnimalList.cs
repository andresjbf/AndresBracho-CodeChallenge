using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Animals
{
    public class AnimalList
    {
        const string filename = @"..\..\SavedAnimalList.bin";

        /// <summary>
        /// Method to load animal list file or default list if none is found
        /// </summary>
        /// <returns>returns a list of animals objects</returns>
        public static List<Animal> LoadAnimalList()
        {
            var animalist = new List<Animal>();
            
            //If animal list exsists load animals from file. Else load default animals
            if (File.Exists(filename))
            {
                Stream testFileStream = File.OpenRead(filename);
                BinaryFormatter deserializer = new BinaryFormatter();

                animalist = (List<Animal>)deserializer.Deserialize(testFileStream);
                testFileStream.Close();
            }
            else
            {
                Animal lion = new Animal("lion", "yellow", "roar");
                Animal elephant = new Animal("elephant", "grey", "trumpet");
                animalist.Add(lion);
                animalist.Add(elephant);
            }

            return animalist;

        }

         /// <summary>
         /// Method to add an animal to the binary file
         /// </summary>
        public static void AddAnimal()
        {
            List<Animal> animalist = LoadAnimalList();
            Console.WriteLine("Please enter the name of your animal");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter the color of your animal");
            string color = Console.ReadLine();

            Console.WriteLine("Please enter the noise your animal makes");
            string noise = Console.ReadLine();

            //var NewAnimal = Activator.CreateInstance("Animal", name);
            Animal NewAnimal = new Animal(name, color, noise);
            animalist.Add(NewAnimal);

            SaveAnimalList(animalist);
        }

        /// <summary>
        /// Method to save current animal list to the binary file
        /// </summary>
        /// <param name="AnimalList">List of animals</param>
        public static void SaveAnimalList(List<Animal> AnimalList)
        {
            Stream TestFileStream = File.Create(filename);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, AnimalList);
            TestFileStream.Close();
        }


    }
}
