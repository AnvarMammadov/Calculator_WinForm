using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_WinForm
{
    public partial class Form1 : Form
    {
        double firstValue, secondValue;
        string operationName,instance="";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            try
            {
                var btnNum = (Button)sender;
                if (txtbResult.Text == "0") txtbResult.Text = "";
                {
                    if (btnNum.Text == ".")
                    {
                        if (!txtbResult.Text.Contains(".")) txtbResult.Text += btnNum.Text;
                    }
                    else txtbResult.Text += btnNum.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }


        }

        private void OperatorButtonClick(object sender, EventArgs e)
        {
            try
            {
                var btnOp = (Button)sender;
                firstValue = Convert.ToDouble(txtbResult.Text);
                operationName = btnOp.Name;
                txtbResult.Text = "0";
                instance += OtherHelperFunctions.FirstOperationInstanceText(firstValue, btnOp.Name);
                lblInstance.Text = instance;
                DisableOperationPoint();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                secondValue = Convert.ToDouble(txtbResult.Text);
                switch (operationName)
                {
                    case "btnSum":
                        txtbResult.Text = MathOperations.Sum(firstValue, secondValue).ToString();
                        break;
                    case "btnSubt":
                        txtbResult.Text = MathOperations.Subt(firstValue, secondValue).ToString();
                        break;
                    case "btnMult":
                        txtbResult.Text = MathOperations.Mult(firstValue, secondValue).ToString();
                        break;
                    case "btnDev":
                        txtbResult.Text = MathOperations.Devide(firstValue, secondValue).ToString(CultureInfo.InvariantCulture);
                        break;
                    default:
                        break;
                }
                instance += OtherHelperFunctions.EqualOperationInstanceText(secondValue);
                lblInstance.Text = instance;
                instance = "";
                EnableOperationPoint();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            try
            {
                txtbResult.Text = "0";
                string first, second;
                first = Convert.ToString(firstValue);
                second = Convert.ToString(secondValue);
                instance = "";
                lblInstance.Text = "";
                first = ""; second = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }

        }

        private void btnNegOrPos_Click(object sender, EventArgs e)
        {
            try
            {
                double numNeg = Convert.ToDouble(txtbResult.Text);
                txtbResult.Text = Convert.ToString(-1 * numNeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }

        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbResult.Text.Length > 0)
                {
                    txtbResult.Text = txtbResult.Text.Remove(txtbResult.Text.Length - 1, 1);
                }
                if (txtbResult.Text.Length == 0) txtbResult.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }


        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            try
            {
                firstValue = Convert.ToDouble(txtbResult.Text);
                txtbResult.Text = MathOperations.Pow2(firstValue).ToString();
                instance += $"sqr ( {firstValue} ) ";
                lblInstance.Text = instance;
                instance = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }

        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            try
            {
                firstValue = Convert.ToDouble(txtbResult.Text);
                txtbResult.Text = MathOperations.Sqrt2(firstValue).ToString();
                instance += $"sqrt ( {firstValue} ) ";
                lblInstance.Text = instance;
                instance = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }

        }

        private void btnDenominator_Click(object sender, EventArgs e)
        {

            try
            {
                firstValue = Convert.ToDouble(txtbResult.Text);
                txtbResult.Text = MathOperations.GetDenominatorNum(firstValue).ToString();
                instance += $"1 / {firstValue} ";
                lblInstance.Text = instance;
                instance = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }

        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            try
            {
                firstValue = Convert.ToDouble(txtbResult.Text);
                txtbResult.Text = MathOperations.GetPercentNumber(firstValue).ToString();
                instance += $"100 / {firstValue}";
                lblInstance.Text = instance;
                instance = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtbResult.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileManage.LogError(ex);
            }

        }

        private void DisableOperationPoint()
        {
            btnSum.Enabled = false;
            btnSubt.Enabled = false;
            btnMult.Enabled = false;
            btnDev.Enabled = false;
            btnDev.BackgroundImage = Properties.Resources.devideblack;
            btnSqrt.Enabled = false;
            btnSqrt.BackgroundImage = Properties.Resources.sqrtblack;
            btnPow.Enabled = false;
            btnPow.BackgroundImage = Properties.Resources.squareblack;
            btnPercent.Enabled = false;
            btnDenominator.Enabled = false;
        }

        private void EnableOperationPoint()
        {
            btnSum.Enabled = true;
            btnSubt.Enabled = true;
            btnMult.Enabled = true;
            btnDev.Enabled = true;
            btnDev.BackgroundImage = Properties.Resources.devide;
            btnSqrt.Enabled = true;
            btnSqrt.BackgroundImage = Properties.Resources.sqrt;
            btnPow.Enabled = true;
            btnPow.BackgroundImage = Properties.Resources.square;
            btnPercent.Enabled = true;
            btnDenominator.Enabled = true;
        }
    }
}
