using System;
using System.Collections.Generic;
using System.Linq;
namespace GuessTheAnimal
{
    /// <summary>
    /// Main class to run the game
    /// </summary>
    public class GuessGame
    {
        public List<Animals.Animal> AnimaList = Animals.AnimalList.LoadAnimalList();
        public List<string> PossibleColors;
        public List<string> PossibleNoise;
        public char lastquestion;

         /// <summary>
         /// Caller method to play game
         /// </summary>
        public void PlayGame()
        {
            PossibleColors = AnimaList.Select(p => p.Color).Distinct().ToList();
            PossibleNoise = AnimaList.Select(p => p.Noise).Distinct().ToList();
            lastquestion = 'n';

            for (int i=1; i< PossibleColors.Count()+PossibleNoise.Count(); i++)
            {
                AskQuestion(AnimaList);
                if (AnimaList.Count() == 1)
                {
                    break;
                }
            }

            Guess();
        }

        /// <summary>
        /// Method to ask alternate color and noise questions and remove animals from list by process of elimination
        /// TD: Should separate this method into two 
        /// </summary>
        /// <param name="animalist">list of animals</param>
        public void AskQuestion(List<Animals.Animal> animalist)
        {
            if (lastquestion == 'n')
            {
                string colortocheck = animalist[0].Color.ToString();

                Console.Out.WriteLine("Is your animal " + colortocheck + "? (y/n)");
                var input = Console.ReadLine();

                if (input.ToLower().Equals("y"))
                {
                    AnimaList.RemoveAll(x => x.Color != colortocheck);
                    lastquestion = 'c';
                }
                else if (input.ToLower().Equals("n"))
                {
                    AnimaList.RemoveAll(x => x.Color == colortocheck);
                    lastquestion = 'c';
                }
                else
                {
                    Console.Out.WriteLine("Please enter y or n");
                }

            }
            else if (lastquestion == 'c')
            {
                string noisetocheck = animalist[0].Noise.ToString();
                Console.Out.WriteLine("Does your animal " + noisetocheck + "? (y/n)");
                var input = Console.ReadLine();

                if (input.ToLower().Equals("y"))
                {
                    AnimaList.RemoveAll(x => x.Noise != noisetocheck);
                    lastquestion = 'n';
                }
                else if (input.ToLower().Equals("n"))
                {
                    AnimaList.RemoveAll(x => x.Noise == noisetocheck);
                    lastquestion = 'n';
                }
                else
                {
                    Console.Out.WriteLine("Please enter y or n");
                }

            }
        }

        /// <summary>
        /// Guess the animal if available
        /// </summary>
        public void Guess()
        {
            if(AnimaList.Count() == 1)
            {
                Console.WriteLine("Your animal is " + AnimaList[0].Name.ToString());
            }
            else
            {
                Console.WriteLine("your animal could not be guessed");
            }
        }

        /// <summary>
        /// Method to determine if the user wants to play again
        /// </summary>
        /// <returns>bool true if user wants to play again, false otherwise</returns>
        public bool PlayAgain()
        {
            Console.WriteLine("Play Again? (y/n)");
            var input = Console.ReadLine();
            bool PlayAgainToken = true;

            if (input.ToLower().Equals("y"))
            {
                PlayAgainToken = true;
            }
            else if (input.ToLower().Equals("n"))
            {
                Console.WriteLine("Thank you for playing");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please enter a valid input");
                PlayAgain();
            }

            return PlayAgainToken;
        }
    }
}
