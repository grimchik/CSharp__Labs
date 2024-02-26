using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
namespace Lab1_maui;

public partial class IntegralCalculation : ContentPage
{
    private CancellationTokenSource cancelTokenSource;
    private CancellationToken token;
    private bool realeseStatus = false;
    public IntegralCalculation()
	{
		InitializeComponent();
        cancelTokenSource = new CancellationTokenSource();
        token = cancelTokenSource.Token;
    }
    private async void StartButton_Clicked(object sender, EventArgs e)
    {
        if (!token.IsCancellationRequested && realeseStatus == false)
        {
            realeseStatus = true;
            Value.Text = "Calculating...";
            ProgressBar? progress = this.FindByName("Prgs") as ProgressBar;
            double completionPercent = 0.0;
            double res = 0;
            double A = 0, B = 1;
            double step = 0.00000001;
            double step2 = 0.00001;
            try
            {
                for (double i = A; i <= B; i += step2)
                {
                    await Task.Delay(1);
                    token.ThrowIfCancellationRequested();
                    res += Math.Sin(i) * step;
                    completionPercent = (i - A) / (B - A) * 100;
                    progress.Progress = completionPercent;
                    ProgressLabel.Text = Convert.ToString(Math.Round(completionPercent * 100)) + "%";
                    if (Math.Round(completionPercent * 100) >= 100) break;
                }
                progress.Progress = 1.0;
                Value.Text = Convert.ToString(res * 10000000);
                realeseStatus = false;
                cancelTokenSource = new CancellationTokenSource();
                token = cancelTokenSource.Token;
            }
            catch (OperationCanceledException)
            {
                cancelTokenSource = new CancellationTokenSource();
                token = cancelTokenSource.Token;
            }
            finally
            {
                realeseStatus = false;
            }
        }
    }
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        ProgressBar? progress = this.FindByName("Prgs") as ProgressBar;
        if (progress.Progress < 1.0 && Value.Text != "Operation canceled!")
        {
            cancelTokenSource.Cancel();
            Value.Text = "Operation canceled!";
        }
    }
}