using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCards.Models
{
    public class ResultHolderModel
    {
        private int _numberOfBoxes; // Number of boxes purchased
        private long _counter; //How many times this result occurred

        public int NumberOfBoxes
        {
            get {return _numberOfBoxes; }
            set
            {
                if (_numberOfBoxes == value) return;
                else
                {
                    _numberOfBoxes = value;
                }
            }
        }

        public long Counter
        {
            get { return _counter; }
            set
            {
                if (_counter == value) return;
                else
                {
                    _counter = value;
                }
            }
        }
    }
}
