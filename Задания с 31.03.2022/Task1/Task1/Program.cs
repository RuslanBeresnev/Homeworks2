namespace Calc;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var calcLogic = new CalcLogic();
        var calcForm = new CalcForm(calcLogic);

        Application.Run(calcForm);
    }
}