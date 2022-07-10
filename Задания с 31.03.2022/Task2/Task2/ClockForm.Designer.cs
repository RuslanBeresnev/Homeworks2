namespace Clock;

partial class ClockForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.number12 = new System.Windows.Forms.Label();
            this.number3 = new System.Windows.Forms.Label();
            this.number6 = new System.Windows.Forms.Label();
            this.number9 = new System.Windows.Forms.Label();
            this.number1 = new System.Windows.Forms.Label();
            this.number2 = new System.Windows.Forms.Label();
            this.number11 = new System.Windows.Forms.Label();
            this.number10 = new System.Windows.Forms.Label();
            this.number4 = new System.Windows.Forms.Label();
            this.number5 = new System.Windows.Forms.Label();
            this.number7 = new System.Windows.Forms.Label();
            this.number8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // number12
            // 
            this.number12.AutoSize = true;
            this.number12.BackColor = System.Drawing.Color.White;
            this.number12.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number12.Location = new System.Drawing.Point(225, 105);
            this.number12.Name = "number12";
            this.number12.Size = new System.Drawing.Size(53, 36);
            this.number12.TabIndex = 0;
            this.number12.Text = "12";
            // 
            // number3
            // 
            this.number3.AutoSize = true;
            this.number3.BackColor = System.Drawing.Color.White;
            this.number3.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number3.Location = new System.Drawing.Point(360, 233);
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(34, 36);
            this.number3.TabIndex = 1;
            this.number3.Text = "3";
            // 
            // number6
            // 
            this.number6.AutoSize = true;
            this.number6.BackColor = System.Drawing.Color.White;
            this.number6.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number6.Location = new System.Drawing.Point(232, 360);
            this.number6.Name = "number6";
            this.number6.Size = new System.Drawing.Size(34, 36);
            this.number6.TabIndex = 2;
            this.number6.Text = "6";
            // 
            // number9
            // 
            this.number9.AutoSize = true;
            this.number9.BackColor = System.Drawing.Color.White;
            this.number9.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number9.Location = new System.Drawing.Point(105, 233);
            this.number9.Name = "number9";
            this.number9.Size = new System.Drawing.Size(34, 36);
            this.number9.TabIndex = 3;
            this.number9.Text = "9";
            // 
            // number1
            // 
            this.number1.AutoSize = true;
            this.number1.BackColor = System.Drawing.Color.White;
            this.number1.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number1.Location = new System.Drawing.Point(299, 131);
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(27, 28);
            this.number1.TabIndex = 4;
            this.number1.Text = "1";
            // 
            // number2
            // 
            this.number2.AutoSize = true;
            this.number2.BackColor = System.Drawing.Color.White;
            this.number2.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number2.Location = new System.Drawing.Point(345, 173);
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(27, 28);
            this.number2.TabIndex = 5;
            this.number2.Text = "2";
            // 
            // number11
            // 
            this.number11.AutoSize = true;
            this.number11.BackColor = System.Drawing.Color.White;
            this.number11.Font = new System.Drawing.Font("Bauhaus 93", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number11.Location = new System.Drawing.Point(168, 129);
            this.number11.Name = "number11";
            this.number11.Size = new System.Drawing.Size(36, 24);
            this.number11.TabIndex = 6;
            this.number11.Text = "11";
            // 
            // number10
            // 
            this.number10.AutoSize = true;
            this.number10.BackColor = System.Drawing.Color.White;
            this.number10.Font = new System.Drawing.Font("Bauhaus 93", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number10.Location = new System.Drawing.Point(123, 178);
            this.number10.Name = "number10";
            this.number10.Size = new System.Drawing.Size(36, 24);
            this.number10.TabIndex = 7;
            this.number10.Text = "10";
            // 
            // number4
            // 
            this.number4.AutoSize = true;
            this.number4.BackColor = System.Drawing.Color.White;
            this.number4.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number4.Location = new System.Drawing.Point(345, 295);
            this.number4.Name = "number4";
            this.number4.Size = new System.Drawing.Size(27, 28);
            this.number4.TabIndex = 8;
            this.number4.Text = "4";
            // 
            // number5
            // 
            this.number5.AutoSize = true;
            this.number5.BackColor = System.Drawing.Color.White;
            this.number5.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number5.Location = new System.Drawing.Point(299, 341);
            this.number5.Name = "number5";
            this.number5.Size = new System.Drawing.Size(27, 28);
            this.number5.TabIndex = 9;
            this.number5.Text = "5";
            // 
            // number7
            // 
            this.number7.AutoSize = true;
            this.number7.BackColor = System.Drawing.Color.White;
            this.number7.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number7.Location = new System.Drawing.Point(174, 341);
            this.number7.Name = "number7";
            this.number7.Size = new System.Drawing.Size(27, 28);
            this.number7.TabIndex = 10;
            this.number7.Text = "7";
            // 
            // number8
            // 
            this.number8.AutoSize = true;
            this.number8.BackColor = System.Drawing.Color.White;
            this.number8.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.number8.Location = new System.Drawing.Point(128, 295);
            this.number8.Name = "number8";
            this.number8.Size = new System.Drawing.Size(27, 28);
            this.number8.TabIndex = 11;
            this.number8.Text = "8";
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.number8);
            this.Controls.Add(this.number7);
            this.Controls.Add(this.number5);
            this.Controls.Add(this.number4);
            this.Controls.Add(this.number10);
            this.Controls.Add(this.number11);
            this.Controls.Add(this.number2);
            this.Controls.Add(this.number1);
            this.Controls.Add(this.number9);
            this.Controls.Add(this.number6);
            this.Controls.Add(this.number3);
            this.Controls.Add(this.number12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "ClockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Timer timer;
    private Label number12;
    private Label number3;
    private Label number6;
    private Label number9;
    private Label number1;
    private Label number2;
    private Label number11;
    private Label number10;
    private Label number4;
    private Label number5;
    private Label number7;
    private Label number8;
}