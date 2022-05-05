namespace Clock;

using System.Drawing.Drawing2D;

public partial class ClockForm : Form
{
    private Graphics graphic;

    private Pen penForDial;
    private Pen penForHourArrow;
    private Pen penForMinuteArrow;
    private Pen penForSecondArrow;

    public ClockForm()
    {
        InitializeComponent();

        graphic = CreateGraphics();

        penForDial = new Pen(Color.Black, 7);
        penForHourArrow = new Pen(Color.Red, 5);
        penForHourArrow.CustomEndCap = new AdjustableArrowCap(3, 3);
        penForMinuteArrow = new Pen(Color.Black, 3);
        penForMinuteArrow.CustomEndCap = new AdjustableArrowCap(3, 3);
        penForSecondArrow = new Pen(Color.Black, 3);
        penForSecondArrow.CustomEndCap = new AdjustableArrowCap(3, 3);
    }

    private void ClockForm_Paint(object sender, PaintEventArgs e)
    {
        graphic.Clear(Color.White);

        graphic.DrawEllipse(penForDial, 100, 75, 300, 300);

        graphic.DrawLine(penForHourArrow, 250, 250,
            250 + 150 * (int) Math.Cos(2 * Math.PI / 12 * (DateTime.Now.Hour % 12)),
            250 + 150 * (int) Math.Sin(2 * Math.PI / 12 * (DateTime.Now.Hour % 12)));
        graphic.DrawLine(penForMinuteArrow, 250, 250,
            250 + 150 * (int)Math.Cos(2 * Math.PI / 12 * DateTime.Now.Minute),
            250 + 150 * (int)Math.Sin(2 * Math.PI / 12 * DateTime.Now.Minute));
        graphic.DrawLine(penForSecondArrow, 250, 250,
            250 + 150 * (int)Math.Cos(2 * Math.PI / 12 * DateTime.Now.Second),
            250 + 150 * (int)Math.Sin(2 * Math.PI / 12 * DateTime.Now.Second));

        penForDial.Dispose();
    }
}