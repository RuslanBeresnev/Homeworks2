namespace Calc;

partial class CalcForm
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
            this.calcWindow = new System.Windows.Forms.TextBox();
            this.number1 = new System.Windows.Forms.Button();
            this.number2 = new System.Windows.Forms.Button();
            this.number3 = new System.Windows.Forms.Button();
            this.plusOperation = new System.Windows.Forms.Button();
            this.minusOperation = new System.Windows.Forms.Button();
            this.number4 = new System.Windows.Forms.Button();
            this.number5 = new System.Windows.Forms.Button();
            this.number6 = new System.Windows.Forms.Button();
            this.multiplicationOperation = new System.Windows.Forms.Button();
            this.divisionOperation = new System.Windows.Forms.Button();
            this.number7 = new System.Windows.Forms.Button();
            this.number8 = new System.Windows.Forms.Button();
            this.number9 = new System.Windows.Forms.Button();
            this.sqrtOperation = new System.Windows.Forms.Button();
            this.equalsOperation = new System.Windows.Forms.Button();
            this.number0 = new System.Windows.Forms.Button();
            this.buttonComma = new System.Windows.Forms.Button();
            this.signInversionOperation = new System.Windows.Forms.Button();
            this.clearOperation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calcWindow
            // 
            this.calcWindow.BackColor = System.Drawing.SystemColors.Window;
            this.calcWindow.Font = new System.Drawing.Font("Franklin Gothic Book", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calcWindow.Location = new System.Drawing.Point(12, 12);
            this.calcWindow.MaximumSize = new System.Drawing.Size(276, 87);
            this.calcWindow.MinimumSize = new System.Drawing.Size(276, 87);
            this.calcWindow.Multiline = true;
            this.calcWindow.Name = "calcWindow";
            this.calcWindow.ReadOnly = true;
            this.calcWindow.Size = new System.Drawing.Size(276, 87);
            this.calcWindow.TabIndex = 0;
            this.calcWindow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // number1
            // 
            this.number1.BackColor = System.Drawing.Color.White;
            this.number1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number1.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number1.Location = new System.Drawing.Point(12, 148);
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(50, 50);
            this.number1.TabIndex = 1;
            this.number1.Text = "1";
            this.number1.UseVisualStyleBackColor = false;
            this.number1.Click += new System.EventHandler(this.NumberClick);
            // 
            // number2
            // 
            this.number2.BackColor = System.Drawing.Color.White;
            this.number2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number2.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number2.Location = new System.Drawing.Point(68, 148);
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(50, 50);
            this.number2.TabIndex = 2;
            this.number2.Text = "2";
            this.number2.UseVisualStyleBackColor = false;
            this.number2.Click += new System.EventHandler(this.NumberClick);
            // 
            // number3
            // 
            this.number3.BackColor = System.Drawing.Color.White;
            this.number3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number3.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number3.Location = new System.Drawing.Point(124, 148);
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(50, 50);
            this.number3.TabIndex = 3;
            this.number3.Text = "3";
            this.number3.UseVisualStyleBackColor = false;
            this.number3.Click += new System.EventHandler(this.NumberClick);
            // 
            // plusOperation
            // 
            this.plusOperation.BackColor = System.Drawing.Color.Silver;
            this.plusOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plusOperation.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusOperation.Location = new System.Drawing.Point(180, 148);
            this.plusOperation.Name = "plusOperation";
            this.plusOperation.Size = new System.Drawing.Size(50, 50);
            this.plusOperation.TabIndex = 4;
            this.plusOperation.Text = "+";
            this.plusOperation.UseVisualStyleBackColor = false;
            this.plusOperation.Click += new System.EventHandler(this.BinaryOperationClick);
            // 
            // minusOperation
            // 
            this.minusOperation.BackColor = System.Drawing.Color.Silver;
            this.minusOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minusOperation.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minusOperation.Location = new System.Drawing.Point(236, 148);
            this.minusOperation.Name = "minusOperation";
            this.minusOperation.Size = new System.Drawing.Size(50, 50);
            this.minusOperation.TabIndex = 5;
            this.minusOperation.Text = "-";
            this.minusOperation.UseVisualStyleBackColor = false;
            this.minusOperation.Click += new System.EventHandler(this.BinaryOperationClick);
            // 
            // number4
            // 
            this.number4.BackColor = System.Drawing.Color.White;
            this.number4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number4.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number4.Location = new System.Drawing.Point(12, 204);
            this.number4.Name = "number4";
            this.number4.Size = new System.Drawing.Size(50, 50);
            this.number4.TabIndex = 6;
            this.number4.Text = "4";
            this.number4.UseVisualStyleBackColor = false;
            this.number4.Click += new System.EventHandler(this.NumberClick);
            // 
            // number5
            // 
            this.number5.BackColor = System.Drawing.Color.White;
            this.number5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number5.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number5.Location = new System.Drawing.Point(68, 204);
            this.number5.Name = "number5";
            this.number5.Size = new System.Drawing.Size(50, 50);
            this.number5.TabIndex = 7;
            this.number5.Text = "5";
            this.number5.UseVisualStyleBackColor = false;
            this.number5.Click += new System.EventHandler(this.NumberClick);
            // 
            // number6
            // 
            this.number6.BackColor = System.Drawing.Color.White;
            this.number6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number6.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number6.Location = new System.Drawing.Point(124, 204);
            this.number6.Name = "number6";
            this.number6.Size = new System.Drawing.Size(50, 50);
            this.number6.TabIndex = 8;
            this.number6.Text = "6";
            this.number6.UseVisualStyleBackColor = false;
            this.number6.Click += new System.EventHandler(this.NumberClick);
            // 
            // multiplicationOperation
            // 
            this.multiplicationOperation.BackColor = System.Drawing.Color.Silver;
            this.multiplicationOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.multiplicationOperation.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.multiplicationOperation.Location = new System.Drawing.Point(180, 204);
            this.multiplicationOperation.Name = "multiplicationOperation";
            this.multiplicationOperation.Size = new System.Drawing.Size(50, 50);
            this.multiplicationOperation.TabIndex = 9;
            this.multiplicationOperation.Text = "*";
            this.multiplicationOperation.UseVisualStyleBackColor = false;
            this.multiplicationOperation.Click += new System.EventHandler(this.BinaryOperationClick);
            // 
            // divisionOperation
            // 
            this.divisionOperation.BackColor = System.Drawing.Color.Silver;
            this.divisionOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.divisionOperation.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.divisionOperation.Location = new System.Drawing.Point(236, 204);
            this.divisionOperation.Name = "divisionOperation";
            this.divisionOperation.Size = new System.Drawing.Size(50, 50);
            this.divisionOperation.TabIndex = 10;
            this.divisionOperation.Text = "/";
            this.divisionOperation.UseVisualStyleBackColor = false;
            this.divisionOperation.Click += new System.EventHandler(this.BinaryOperationClick);
            // 
            // number7
            // 
            this.number7.BackColor = System.Drawing.Color.White;
            this.number7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number7.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number7.Location = new System.Drawing.Point(12, 260);
            this.number7.Name = "number7";
            this.number7.Size = new System.Drawing.Size(50, 50);
            this.number7.TabIndex = 11;
            this.number7.Text = "7";
            this.number7.UseVisualStyleBackColor = false;
            this.number7.Click += new System.EventHandler(this.NumberClick);
            // 
            // number8
            // 
            this.number8.BackColor = System.Drawing.Color.White;
            this.number8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number8.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number8.Location = new System.Drawing.Point(68, 260);
            this.number8.Name = "number8";
            this.number8.Size = new System.Drawing.Size(50, 50);
            this.number8.TabIndex = 12;
            this.number8.Text = "8";
            this.number8.UseVisualStyleBackColor = false;
            this.number8.Click += new System.EventHandler(this.NumberClick);
            // 
            // number9
            // 
            this.number9.BackColor = System.Drawing.Color.White;
            this.number9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number9.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number9.Location = new System.Drawing.Point(124, 260);
            this.number9.Name = "number9";
            this.number9.Size = new System.Drawing.Size(50, 50);
            this.number9.TabIndex = 13;
            this.number9.Text = "9";
            this.number9.UseVisualStyleBackColor = false;
            this.number9.Click += new System.EventHandler(this.NumberClick);
            // 
            // sqrtOperation
            // 
            this.sqrtOperation.BackColor = System.Drawing.Color.Silver;
            this.sqrtOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sqrtOperation.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sqrtOperation.Location = new System.Drawing.Point(180, 260);
            this.sqrtOperation.Name = "sqrtOperation";
            this.sqrtOperation.Size = new System.Drawing.Size(50, 50);
            this.sqrtOperation.TabIndex = 14;
            this.sqrtOperation.Text = "√";
            this.sqrtOperation.UseVisualStyleBackColor = false;
            this.sqrtOperation.Click += new System.EventHandler(this.UnaryOperationClick);
            // 
            // equalsOperation
            // 
            this.equalsOperation.BackColor = System.Drawing.Color.Aquamarine;
            this.equalsOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.equalsOperation.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.equalsOperation.Location = new System.Drawing.Point(180, 316);
            this.equalsOperation.Name = "equalsOperation";
            this.equalsOperation.Size = new System.Drawing.Size(106, 50);
            this.equalsOperation.TabIndex = 15;
            this.equalsOperation.Text = "=";
            this.equalsOperation.UseVisualStyleBackColor = false;
            this.equalsOperation.Click += new System.EventHandler(this.EqualsClick);
            // 
            // number0
            // 
            this.number0.BackColor = System.Drawing.Color.White;
            this.number0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.number0.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.number0.Location = new System.Drawing.Point(12, 316);
            this.number0.Name = "number0";
            this.number0.Size = new System.Drawing.Size(50, 50);
            this.number0.TabIndex = 16;
            this.number0.Text = "0";
            this.number0.UseVisualStyleBackColor = false;
            this.number0.Click += new System.EventHandler(this.NumberClick);
            // 
            // buttonComma
            // 
            this.buttonComma.BackColor = System.Drawing.Color.White;
            this.buttonComma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonComma.Font = new System.Drawing.Font("Franklin Gothic Book", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonComma.Location = new System.Drawing.Point(68, 316);
            this.buttonComma.Name = "buttonComma";
            this.buttonComma.Size = new System.Drawing.Size(50, 50);
            this.buttonComma.TabIndex = 17;
            this.buttonComma.Text = ",";
            this.buttonComma.UseVisualStyleBackColor = false;
            this.buttonComma.Click += new System.EventHandler(this.NumberClick);
            // 
            // signInversionOperation
            // 
            this.signInversionOperation.BackColor = System.Drawing.Color.Silver;
            this.signInversionOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.signInversionOperation.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.signInversionOperation.Location = new System.Drawing.Point(236, 260);
            this.signInversionOperation.Name = "signInversionOperation";
            this.signInversionOperation.Size = new System.Drawing.Size(50, 50);
            this.signInversionOperation.TabIndex = 18;
            this.signInversionOperation.Text = "±";
            this.signInversionOperation.UseVisualStyleBackColor = false;
            this.signInversionOperation.Click += new System.EventHandler(this.UnaryOperationClick);
            // 
            // clearOperation
            // 
            this.clearOperation.BackColor = System.Drawing.Color.White;
            this.clearOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearOperation.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clearOperation.Location = new System.Drawing.Point(124, 316);
            this.clearOperation.Name = "clearOperation";
            this.clearOperation.Size = new System.Drawing.Size(50, 50);
            this.clearOperation.TabIndex = 19;
            this.clearOperation.Text = "C";
            this.clearOperation.UseVisualStyleBackColor = false;
            this.clearOperation.Click += new System.EventHandler(this.ClearClick);
            // 
            // CalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 386);
            this.Controls.Add(this.clearOperation);
            this.Controls.Add(this.signInversionOperation);
            this.Controls.Add(this.buttonComma);
            this.Controls.Add(this.number0);
            this.Controls.Add(this.equalsOperation);
            this.Controls.Add(this.sqrtOperation);
            this.Controls.Add(this.number9);
            this.Controls.Add(this.number8);
            this.Controls.Add(this.number7);
            this.Controls.Add(this.divisionOperation);
            this.Controls.Add(this.multiplicationOperation);
            this.Controls.Add(this.number6);
            this.Controls.Add(this.number5);
            this.Controls.Add(this.number4);
            this.Controls.Add(this.minusOperation);
            this.Controls.Add(this.plusOperation);
            this.Controls.Add(this.number3);
            this.Controls.Add(this.number2);
            this.Controls.Add(this.number1);
            this.Controls.Add(this.calcWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(500, 250);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(316, 425);
            this.MinimumSize = new System.Drawing.Size(316, 425);
            this.Name = "CalcForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calc";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TextBox calcWindow;
    private Button number1;
    private Button number2;
    private Button number3;
    private Button plusOperation;
    private Button minusOperation;
    private Button number4;
    private Button number5;
    private Button number6;
    private Button multiplicationOperation;
    private Button divisionOperation;
    private Button number7;
    private Button number8;
    private Button number9;
    private Button sqrtOperation;
    private Button equalsOperation;
    private Button number0;
    private Button buttonComma;
    private Button signInversionOperation;
    private Button clearOperation;
}