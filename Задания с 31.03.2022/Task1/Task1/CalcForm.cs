namespace Calc;

/// <summary>
/// Класс, реализующий графическую часть калькулятора
/// </summary>
public partial class CalcForm : Form
{
    private CalcLogic logic;

    public CalcForm(CalcLogic logic)
    {
        InitializeComponent();

        this.logic = logic;
        calcWindow.DataBindings.Add("Text", logic, "CalcWindowText", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    /// <summary>
    /// Обработчик нажатия кнопки с цифрой или кнопки с разделителем ","
    /// </summary>
    private void NumberClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.Number, (sender as Button)!.Text);
    }

    /// <summary>
    /// Обработчик нажатия кнопки с бинарной операцией
    /// </summary>
    private void BinaryOperationClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.BinaryOperation, (sender as Button)!.Text);
    }

    /// <summary>
    /// Обработчик нажатия кнопки с унарной операцией
    /// </summary>
    private void UnaryOperationClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.UnaryOperation, (sender as Button)!.Text);
    }

    /// <summary>
    /// Обработчик нажатия кнопки вычисления результата
    /// </summary>
    private void EqualsClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.Equals, (sender as Button)!.Text);
    }

    /// <summary>
    /// Обработчик нажатия кнопки очистки
    /// </summary>
    private void ClearClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.Clear, (sender as Button)!.Text);
    }
}