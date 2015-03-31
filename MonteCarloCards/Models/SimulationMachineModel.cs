using System;
using System.Collections.Generic;

namespace MonteCarloCards.Models
{
    public class SimulationMachineModel
    {

        private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();

        /// <summary>
        /// Runs one card-collecting simulation.  
        /// </summary>
        /// <param name="numberOfPossibleCards">Number of cards to collect as input by user</param>
        /// <returns>Number of boxes purchased</returns>
        public int RunSimulation(int numberOfPossibleCards)
        {
            int numberOfBoxes = 0; //Number of boxes "bought"
            List<int> cards = new List<int>(); //Holds aquired cards for comparison

            //Loop until all "cards" are found
            do
            {

                var nextCard = RandomNumberGenerator.GenerateRandomNumber(1, numberOfPossibleCards + 1); //Generate the next card found

                //Check if the card has already been found
                if (!cards.Contains(nextCard))
                {
                    //If it hasn't already been found, add to the collection
                    cards.Add(nextCard);
                }
                numberOfBoxes++;
            } while (cards.Count < numberOfPossibleCards);

            return numberOfBoxes;
        }
    }
}
