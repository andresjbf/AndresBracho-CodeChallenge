using System;
using System.Collections.Generic;

namespace GuessTheAnimal
{
    class Program
    {
        /// <summary>
        /// Main caller program
        /// </summary>
        static void Main()
        {
            Console.Clear();
            ShowInstructions();

            GuessGame game = new GuessGame();
            game.PlayGame();

            if (game.PlayAgain())
            {
                Main();
            }
        }

        /// <summary>
        /// Show instructions on how to play the game
        /// </summary>
        private static void ShowInstructions()
        {
            Console.Out.WriteLine("Please select an animal from the following list");

            ShowAnimalList();

            Console.Out.WriteLine("To add an animal to the list press + and enter or press any other key to begin the game");

            if (Console.ReadLine() == "+")
            {

                Animals.AnimalList.AddAnimal();
                Main();
            }
        }

        /// <summary>
        /// Show current list of animals
        /// </summary>
        private static void ShowAnimalList()
        {
            List<Animals.Animal> animalist = Animals.AnimalList.LoadAnimalList();

            foreach (Animals.Animal animal in animalist)
            {
                Console.Out.WriteLine(animal.Name);
            }

        }
    }
}
