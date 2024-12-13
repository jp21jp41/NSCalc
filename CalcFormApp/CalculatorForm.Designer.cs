using System.Data;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CalcFormApp;

partial class Form1
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

    #region

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        PlusButton = new Button();
        MinusButton = new Button();
        EqButton = new Button();
        CalcText = new TextBox();
        HexButton = new Button();
        BinButton = new Button();
        DecButton = new Button();
        SVButton = new Button();
        NumberSystemLabel = new Label();
        ErrorLabel = new Label();
        TestLabel = new Label();
        DataSet computedData = new DataSet("Computed Data");
        SuspendLayout();

        void DesignButton(Button B, string name, string text,
            int loc1 = 0, int loc2 = 0, int size1 = 112,
            int size2 = 34)
        {
            B.Name = name;
            B.Text = text;
            B.Location = new Point(loc1, loc2);
            B.Size = new Size(size1, size2);
            B.UseVisualStyleBackColor = true;
            Controls.Add(B);
        }

        void DesignLabel(Label L, string name, string text,
            int loc1 = 0, int loc2 = 0, int size1 = 112,
            int size2 = 34)
        {
            L.Name = name;
            L.Text = text;
            L.Location = new Point(loc1, loc2);
            L.Size = new Size(size1, size2);
            L.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(L);
        }
        // 
        // PlusButton
        // 
        DesignButton(PlusButton, "PlusButton", "+",
            0, 100, 112, 34);
        PlusButton.Click += PlusButton_Click;
        // 
        // MinusButton
        // 
        DesignButton(MinusButton, "MinusButton", "-",
            130, 100, 112, 34);
        MinusButton.Click += MinusButton_Click;
        // 
        // EqButton
        // 
        DesignButton(EqButton, "EqButton", "=",
            260, 100, 112, 34);
        EqButton.Click += EqButton_Click;
        //
        // SVButton
        //
        DesignButton(SVButton, "StoreValueButton",
            "Store Value", 390, 100, 112, 34);
        SVButton.Click += SVButton_Click;
        //
        // DecButton
        //
        DesignButton(DecButton, "DecButton", "Decimal",
            0, 300, 150, 34);
        DecButton.Click += DecButton_Click;
        //
        // HexButton
        //
        DesignButton(HexButton, "HexButton",
            "Hexadecimal", 160, 300, 150, 34);
        HexButton.Click += HexButton_Click;
        //
        // BinButton
        //
        DesignButton(BinButton, "BinButton", "Binary",
            320, 300, 150, 34);
        BinButton.Click += BinButton_Click;
        // 
        // CalcText
        // 
        CalcText.Location = new Point(0, 0);
        CalcText.Multiline = true;
        CalcText.Name = "CalcText";
        CalcText.Size = new Size(685, 95);
        CalcText.TabIndex = 1;
        CalcText.TextChanged += CalcText_TextChanged;
        //
        // NumberSystemLabel
        //
        DesignLabel(NumberSystemLabel, "NumberSystemLabel",
            "System: Decimal", 700, 0, 200, 34);
        //
        // ErrorLabel
        //
        DesignLabel(ErrorLabel, "ErrorLabel", "No Errors Yet", 700, 40,
            200, 34);
        //
        // TestLabel
        //
        DesignLabel(TestLabel, "TestLabel", "", 700, 80, 200, 34);
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 600);
        Controls.Add(CalcText);
        Name = "Form1";
        Text = "Calculator by Number System";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private Button PlusButton;
    private Button MinusButton;
    private Button EqButton;
    private Button HexButton;
    private Button BinButton;
    private Button DecButton;
    private Button SVButton;
    private Label NumberSystemLabel;
    private Label ErrorLabel;
    private Label TestLabel;
    private DataSet computedData;
    private TextBox CalcText;
    
    #endregion
}
