using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace MonteCarloCards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly RNGCryptoServiceProvider Generator = new RNGCryptoServiceProvider();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs one card-collecting simulation.  
        /// </summary>
        /// <param name="numberOfPossibleCards">Number of cards to collect as inptu by user</param>
        /// <returns>Number of boxes purchased</returns>
        private int RunSimulation(int numberOfPossibleCards)
        {
            int numberOfBoxes = 0; //Number of boxes "bought"
            Random rand; //Random number generator
            List<int> cards = new List<int>(); //Holds aquired cards for comparison

            //Loop until all "cards" are found
            do
            {

                var nextCard = GenerateRandomNumber(1, numberOfPossibleCards + 1); //Generate the next card found

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

        /// <summary>
        /// Generic class to hold results and keep track of how many times that result occurred
        /// </summary>
        public class ResultHolder
        {
            public int numberOfBoxes; // Number of boxes purchased
            public long counter; //How many times this result occurred
        }

        /// <summary>
        /// Starts simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runSimulationButton_clicked(object sender, RoutedEventArgs e)
        {
            List<ResultHolder> allResults = new List<ResultHolder>();
                //Holds all of our results until it is time for our final calculations

            for (int i = 0; i < Convert.ToInt64(numOfSimulations.Text); i++)
            {
                var result = RunSimulation(Convert.ToInt16(numOfCards.Text));
                    // Run your simulation, get back how many total boxes you had to buy

                //If our list of results does not already contain this result, insert it...
                if (!allResults.Any(a => a.numberOfBoxes.Equals(result)))
                {
                    allResults.Add(new ResultHolder() {numberOfBoxes = result, counter = 1});
                }
                else //Else, increment that counter!
                {
                    foreach (ResultHolder item in allResults)
                    {
                        if (item.numberOfBoxes.Equals(result))
                        {
                            item.counter++;
                        }
                    }
                }
            }

            List<ResultHolder> orderedResults = allResults.OrderBy(o => o.numberOfBoxes).ToList();

            foreach (ResultHolder item in orderedResults)
            {
                Debug.WriteLine(@"Boxes: " + item.numberOfBoxes + " Number of times: " + item.counter);
            }
        }

        /// <summary>
        /// The following method was taken directly from scottlilly.com (http://scottlilly.com/create-better-random-numbers-in-c/)
        /// This is an improved random number generator, since C#'s native random number generator is not very... random.
        /// </summary>
        /// <param name="minimumValue"></param>
        /// <param name="maximumValue"></param>
        /// <returns></returns>
            public static int GenerateRandomNumber(int minimumValue, int maximumValue)
            {
                byte[] randomNumber = new byte[1];

                Generator.GetBytes(randomNumber);

                double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

                // We are using Math.Max, and substracting 0.00000000001, 
                // to ensure "multiplier" will always be between 0.0 and .99999999999
                // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
                double multiplier = Math.Max(0, (asciiValueOfRandomCharacter/255d) - 0.00000000001d);

                // We need to add one to the range, to allow for the rounding done with Math.Floor
                int range = maximumValue - minimumValue + 1;

                double randomValueInRange = Math.Floor(multiplier*range);

                return (int) (minimumValue + randomValueInRange);
            }
        }
}