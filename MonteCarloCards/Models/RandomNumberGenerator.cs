using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCards.Models
{
    public class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider Generator = new RNGCryptoServiceProvider();

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
