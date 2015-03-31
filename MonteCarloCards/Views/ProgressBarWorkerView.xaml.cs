using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace MonteCarloCards
{
    /// <summary>
    /// Interaction logic for ProgressBarWorkerWindow.xaml
    /// </summary>
    public partial class ProgressBarWorkerWindow : Window
    {
        public ProgressBarWorkerWindow(int numberOf)
        {
            InitializeComponent();
        }
        
                private void Window_ContentRendered(object sender, EventArgs e)
                {
                        BackgroundWorker worker = new BackgroundWorker();
                        worker.WorkerReportsProgress = true;
                        worker.DoWork += worker_DoWork;
                        worker.ProgressChanged += worker_ProgressChanged;

                        worker.RunWorkerAsync();
                }

                void worker_DoWork(object sender, DoWorkEventArgs e)
                {
                        for(int i = 0; i < 100; i++)
                        {
                            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
                            if (backgroundWorker != null) backgroundWorker.ReportProgress(i);
                            Thread.Sleep(100);
                        }
                }

                void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
                {
                        pbStatus.Value = e.ProgressPercentage;
                }
        }
}
