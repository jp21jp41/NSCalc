using System.Collections.Generic;
using System.DirectoryServices;
using System.Numerics;
using System.Runtime.Serialization;
using Microsoft.VisualBasic.Devices;

namespace WinFormsApp1
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
            string system = "0", int i = 0)
        {
            List<string> systems = ["Decimal", "Hexadecimal", "Binary"];
            int systemnum = systems.IndexOf(system);
            switch (systemnum)
            {
                case 0:
                    switch (i)
                    {
                        case 0:
                            int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
                            ErrorLabel.Text = Convert.ToString(result);
                            break;
                        case 1:
                            result = Convert.ToInt32(value1) / Convert.ToInt32(value2);
                            ErrorLabel.Text = Convert.ToString(result);
                            break;
                        case 2:
                            result = Convert.ToInt32(value1) + Convert.ToInt32(value2);
                            ErrorLabel.Text = Convert.ToString(result);
                            break;
                        case 3:
                            result = Convert.ToInt32(value1) - Convert.ToInt32(value2);
                            ErrorLabel.Text = Convert.ToString(result);
                            break;
                        default:
                            ErrorLabel.Text = value1;
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
            int Length = Text.Length;
            try
            {
                if (Length == Text.LastIndexOf("="))
                {
                    ExpressionRunner(Text[..(Length - 1)]);
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
            char[] operators = { '*', '/', '-', '+' };
            if (text.IndexOfAny(operators) == 0 |
                text.IndexOfAny(operators) == text.Length)
            {

            }
            else
            {
                if (text.IndexOfAny(operators) != -1)
                {
                    string PartialOne = text[..text.IndexOfAny(operators)];
                    bool test1 = NumberSystemSearch(PartialOne);
                    if (test1)
                    {
                        text = text[text.IndexOfAny(operators)..];
                        int next = text.IndexOfAny(operators);
                        switch (next)
                        {
                            case -1:
                                string PartialTwo = text[text.IndexOfAny(operators)..];
                                bool test2 = NumberSystemSearch(PartialTwo);
                                if (test2)
                                {
                                    Compute(PartialOne, PartialTwo, "Decimal", 0);
                                }
                                break;
                            default:
                                PartialTwo = text[text.IndexOfAny(operators)..next];
                                Compute(PartialOne, PartialTwo, "Decimal", 0);
                                break;
                        }
                    }
                }
                else if (text != "")
                {
                    bool test1 = NumberSystemSearch(text);
                    if (test1)
                    {
                        CalcText.Text = text;
                        Compute(text, "", "Decimal", -1);
                    }
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
