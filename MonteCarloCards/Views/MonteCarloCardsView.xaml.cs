using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using MonteCarloCards.Models;
using MonteCarloCards.ViewModels;

namespace MonteCarloCards.Views
{
    /// <summary>
    /// Interaction logic for MonteCarloCardsView.xaml
    /// </summary>
    public partial class MonteCarloCardsView
    {
        readonly MonteCarloCardsViewModel _viewmodel = new MonteCarloCardsViewModel();

        public MonteCarloCardsView()
        {
            InitializeComponent();
            DataContext = _viewmodel;
        }

        /// <summary>
        /// Starts simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runSimulationButton_clicked(object sender, RoutedEventArgs e)
        {
            int numOfSimulations = Convert.ToInt32(NumOfSimulations.Text);
            int numOfCards = Convert.ToInt32(NumOfCards.Text);

            _viewmodel.StartSimulations(numOfSimulations, numOfCards);

        }
    }
}