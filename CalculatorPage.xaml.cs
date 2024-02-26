namespace Lab1_maui;

public partial class CalculatorPage : ContentPage
{
    private bool status = false;
    private bool statusError = false;
    private bool statusComma = false;
    private bool statusSum = false;
    private bool statusSubtraction = false;
    private bool statusMultiply = false;
    private bool statusDivision = false;
    public CalculatorPage()
	{
		InitializeComponent();
    }
    private double value;
    private double value1;
    private double value2;
    private void DigitalButtonClicked(object sender, EventArgs e)
    {
        if (status) { Value.Text = ""; statusError = false; status = false; statusComma = false; }

        Button button = (Button)sender;
        if (Value.Text != "0")
        Value.Text += button.Text;
        else
        {
            Value.Text = button.Text;
        }
    }

    private void ButtonLogX_Clicked(object sender, EventArgs e)
    {
        string enteredValue = Value.Text;
        if (enteredValue == "")
        {
            string str = "Incorrect Input!";
            Value.Text = str;
            status = true;
            statusError = true;
        }
        else
        {
            if (enteredValue == "0" || enteredValue[0] == '-' || enteredValue == "Incorrect Input!" || enteredValue == ",")
            {
                string str = "Incorrect Input!";
                Value.Text = str;
                status = true;
                statusError = true;
            }
            else
            {
                value = Lab1_maui.Calculator.toNumber(enteredValue);
                value = Math.Log10(value);
                string str = Convert.ToString(value);
                Value.Text = str;
                status = true;
            }
        }
    }

    private void ButtonComma_Clicked(object sender, EventArgs e)
    {
        if (status) { Value.Text = ""; status = false; statusError = false; statusComma = false; }
        if (Value.Text == "Incorrect Input!")
        { Value.Text = "Incorrect Input!"; }
        if (statusComma == false)
        {
            if (Value.Text == "0" || Value.Text=="")
            Value.Text = "0,";
            else
                Value.Text += ",";
            statusComma = true;
        }
    }

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        Value.Text = "";
        value = 0;
        value1 = 0;
        value2 = 0;
        status = false; statusError = false; statusComma = false;
    }
    private void PlusMinusButton_Clicked(object sender, EventArgs e)
    {
        if (statusError) { Value.Text = ""; statusError = false; status = false; statusComma = false; }
        string enteredValue = Value.Text;
        value = Lab1_maui.Calculator.toNumber(enteredValue);
        if (value !=0)
        value *=-1;
        string str = Convert.ToString(value);
        Value.Text = str;
    }

    private void DivisionButton_Clicked(object sender, EventArgs e)
    {
        string enteredValue = Value.Text;
        value1 = Lab1_maui.Calculator.toNumber(enteredValue);
        string str = "";
        Value.Text = str;
        statusDivision = true;
    }

    private void MultiplyButton_Clicked(object sender, EventArgs e)
    {
        string enteredValue = Value.Text;
        value1 = Lab1_maui.Calculator.toNumber(enteredValue);
        string str = "";
        Value.Text = str;
        statusMultiply = true;
    }

    private void ResultButton_Clicked(object sender, EventArgs e)
    {
        if (Value.Text == "Incorrect Input!")
        {
            Value.Text = "";
        }
        else
        {
            if (statusSum == true)
            {
                string enteredValue = Value.Text;
                value2 = Lab1_maui.Calculator.toNumber(enteredValue);
                value = value1 + value2;
                string str = Convert.ToString(value);
                Value.Text = str;
                statusSum = false;
            }
            if (statusSubtraction == true)
            {
                string enteredValue = Value.Text;
                value2 = Lab1_maui.Calculator.toNumber(enteredValue);
                value = value1 - value2;
                string str = Convert.ToString(value);
                Value.Text = str;
                statusSubtraction = false;
            }
            if (statusMultiply == true)
            {
                string enteredValue = Value.Text;
                value2 = Lab1_maui.Calculator.toNumber(enteredValue);
                value = value1 * value2;
                string str = Convert.ToString(value);
                Value.Text = str;
                statusMultiply = false;
            }
            if (statusDivision == true)
            {
                string enteredValue = Value.Text;
                value2 = Lab1_maui.Calculator.toNumber(enteredValue);
                if (value2 != 0)
                {
                    value = value1 / value2;
                    string str = Convert.ToString(value);
                    Value.Text = str;
                    statusDivision = false;
                }
                else
                {
                    Value.Text = "Incorrect Input!";
                }
            }
            status = true;
            value1 = 0;
            value2 = 0;
        }
    }

    private void SumButton_Clicked(object sender, EventArgs e)
    {
        string enteredValue = Value.Text;
        value1 = Lab1_maui.Calculator.toNumber(enteredValue);
        string str = "";
        Value.Text = str;
        statusSum = true;
    }

    private void SubtractionButton_Clicked(object sender, EventArgs e)
    {
        string enteredValue = Value.Text;
        value1 = Lab1_maui.Calculator.toNumber(enteredValue);
        string str = "";
        Value.Text = str;
        statusSubtraction = true;
    }

    private void PercentButton_Clicked(object sender, EventArgs e)
    {
        if (statusError) { Value.Text = ""; statusError = false; status = false; statusComma = false; }
        string enteredValue = Value.Text;
        if (enteredValue != ",")
        {
            value = Lab1_maui.Calculator.toNumber(enteredValue);
            if (value != 0 && value > 0)
                value /= 100;
            else value = 0;
            string str = Convert.ToString(value);
            Value.Text = str;
        }
        else
        {
            Value.Text = "0";
        }
    }
}

