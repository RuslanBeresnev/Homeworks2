namespace Calc;

public partial class CalcForm : Form
{
    public CalcForm()
    {
        InitializeComponent();
    }

    public void CalcWindowSetText(string text)
    {
        calcWindow.Text = text;
    }
}