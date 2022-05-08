namespace Calc;

/// <summary>
/// �����, ����������� ����������� ����� ������������
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
    /// ���������� ������� ������ � ������ ��� ������ � ������������ ","
    /// </summary>
    private void NumberClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.Number, (sender as Button)!.Text);
    }

    /// <summary>
    /// ���������� ������� ������ � �������� ���������
    /// </summary>
    private void BinaryOperationClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.BinaryOperation, (sender as Button)!.Text);
    }

    /// <summary>
    /// ���������� ������� ������ � ������� ���������
    /// </summary>
    private void UnaryOperationClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.UnaryOperation, (sender as Button)!.Text);
    }

    /// <summary>
    /// ���������� ������� ������ ���������� ����������
    /// </summary>
    private void EqualsClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.Equals, (sender as Button)!.Text);
    }

    /// <summary>
    /// ���������� ������� ������ �������
    /// </summary>
    private void ClearClick(object sender, EventArgs e)
    {
        logic.ChangeState(ButtonType.Clear, (sender as Button)!.Text);
    }
}