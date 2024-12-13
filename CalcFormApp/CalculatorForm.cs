using System.Collections.Generic;
using System.DirectoryServices;
using System.Numerics;
using System.Runtime.Serialization;
using Microsoft.VisualBasic.Devices;

namespace CalcFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            CalcText.Text += "+";
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            CalcText.Text += "-";
        }

        private void EqButton_Click(object sender, EventArgs e)
        {
            CalcText.Text += "=";
        }

        private void SVButton_Click(object sender, EventArgs e)
        {
            
            CalcText.Text = "";
        }

        private void DecButton_Click(object sender, EventArgs e)
        {
            NumberSystemLabel.Text = "System: Decimal";
        }

        private void HexButton_Click(object sender, EventArgs e)
        {
            NumberSystemLabel.Text = "System: Hexadecimal";
        }

        private void BinButton_Click(object sender, EventArgs e)
        {
            NumberSystemLabel.Text = "System: Binary";
        }

        private void Compute(string value1 = "0", string value2 = "0", 
            string system = "Decimal", int i = 0)
        {
            List<string> systems = ["Decimal", "Hexadecimal", "Binary"];
            int systemnum = systems.IndexOf(system);
            switch (systemnum)
            {
                case 0:
                    switch (i)
                    {
                        case 0:
                            try
                            {
                                int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
                                TestLabel.Text = Convert.ToString(result);
                            }
                            catch
                            {
                                TestLabel.Text = value1;
                            }
                            break;
                        case 1:
                            try
                            {
                                int result = Convert.ToInt32(value1) / Convert.ToInt32(value2);
                                TestLabel.Text = Convert.ToString(result);
                            }
                            catch
                            {
                                TestLabel.Text = value1;
                            }
                            break;
                        case 2:
                            try
                            {
                                int result = Convert.ToInt32(value1) + Convert.ToInt32(value2);
                                TestLabel.Text = Convert.ToString(result);
                            }
                            catch 
                            {
                                TestLabel.Text = value1;
                            }
                            break;
                        case 3:
                            try
                            {
                                int result = Convert.ToInt32(value1) - Convert.ToInt32(value2);
                                TestLabel.Text = Convert.ToString(result);
                            }
                            catch
                            {
                                TestLabel.Text = value1;
                            }
                            break;
                        default:
                            TestLabel.Text = value1;
                            break;
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;

            }
        }
        private void CalcText_TextChanged(object sender, EventArgs e)
        {
            Text = CalcText.Text;
            int end = Text.Length - 1;
            try
            {
                if (end == Text.LastIndexOf("="))
                {
                    ExpressionRunner(Text[..end]);
                    CalcText.Text = TestLabel.Text;
                }
                else
                {
                    ExpressionRunner(Text);
                }
            }
            catch { }
            {
                
            }
            }

        private void ExpressionRunner(string text)
        {
            char[] operators = { '*', '/', '+', '-' };
            string op_str = "*/+-";
            if (text.IndexOfAny(operators) == 0 |
                text.IndexOfAny(operators) == text.Length)
            {

            }
            else
            {
                int op1 = text.IndexOfAny(operators);
                int opvalue = op_str.IndexOf(text[op1]);
                ErrorLabel.Text = Convert.ToString(opvalue);
                string LHS = text[..op1];
                try
                {
                    string RHS = text[(op1 + 1)..];
                    Compute(LHS, RHS, "Decimal", opvalue);
                }
                catch
                {
                    
                }
            }
        }
        private bool NumberSystemSearch(string partial) 
        {
            if (NumberSystemLabel.Text == "System: Decimal")
            {
                try
                {
                    Convert.ToInt32(partial);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if (NumberSystemLabel.Text == "System: Hexadecimal")
            {
                /*
                 * false for now
                 */
                return false;
            }
            else
            {
                /*
                 * false for now
                 */
                return false;
            }
            
        }
    }

}
