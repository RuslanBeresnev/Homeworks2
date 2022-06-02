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

        penForDial = new Pen(Color.Black, 6);
        penForHourArrow = new Pen(Color.Black, 5);
        penForHourArrow.CustomEndCap = new AdjustableArrowCap(3, 3);
        penForMinuteArrow = new Pen(Color. Black, 3);
        penForMinuteArrow.CustomEndCap = new AdjustableArrowCap(3, 3);
        penForSecondArrow = new Pen(Color.Red, 2);
        penForSecondArrow.CustomEndCap = new AdjustableArrowCap(3, 3);

        TimerTick(this, EventArgs.Empty);

    }

    private void TimerTick(object sender, EventArgs e)
    {
        graphic.Clear(Color.White);

        graphic.DrawEllipse(penForDial, 100, 100, 300, 300);
        graphic.DrawEllipse(penForDial, 246, 246, 8, 8);

        graphic.DrawLine(penForHourArrow, 250, 250,
            250 + 90 * (float)Math.Sin(2 * Math.PI / 12 * (DateTime.Now.Hour % 12)),
            250 - 90 * (float)Math.Cos(2 * Math.PI / 12 * (DateTime.Now.Hour % 12)));
        graphic.DrawLine(penForMinuteArrow, 250, 250,
            250 + 105 * (float)Math.Sin(2 * Math.PI / 60 * DateTime.Now.Minute),
            250 - 105 * (float)Math.Cos(2 * Math.PI / 60 * DateTime.Now.Minute));
        graphic.DrawLine(penForSecondArrow, 250, 250,
            250 + 105 * (float)Math.Sin(2 * Math.PI / 60 * DateTime.Now.Second),
            250 - 105 * (float)Math.Cos(2 * Math.PI / 60 * DateTime.Now.Second));
    }
}