using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hair_salon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //a method to return value for hair dresser
        private double hairDresser()
        {
            double hairDresser = 0.00;
            if (radJane.Checked)
            {
                hairDresser = 30.00;
            }
            else if (radPat.Checked)
            {
                hairDresser = 45.00;
            }
            else if (radRon.Checked)
            {
                hairDresser = 40.00;
            }
            else if (radSve.Checked)
            {
                hairDresser = 50.00;
            }
            else if (radLaura.Checked)
            {
                hairDresser = 55.00;
            }
            return hairDresser;
        }

        //a method that will return the price for service
        private double service()
        {
            double serviceType=0.00;
            if(chkColour.Checked)
            {
                serviceType = serviceType + 40;
            }
            if(chkCut.Checked)
            {
                serviceType = serviceType + 30;
            }
            if(chkHighLights.Checked)
            {
                serviceType = serviceType + 50;
            }
            if(chkExtension.Checked)
            {
                serviceType = serviceType + 200;
            }
            return serviceType;
        }
        //A method that will return the discount price for client type
        private double clientType()
        {
            double discountPercent = 0.00;
            if (radStandard.Checked)
            {
                discountPercent = 0.00;
            }
            else if (radChild.Checked)
            {
                discountPercent = 0.10;
            }
            else if (radStudent.Checked)
            {
                discountPercent = 0.05;
            }
            else if (radSenior.Checked)
                discountPercent = 0.15;
            return discountPercent;
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Variable that holds total price
            double total;
            //declare and assign number of vist to numVist varaible from user input text box
            int numVisit = int.Parse(txtVist.Text);
            //get and assign discount for clientType method to local variable discountClient
            double discountClient = clientType();
            //Check if the numVisit is postive integer
            if(numVisit>0)
            {
                //Check if the user select atleast one service
                if (chkCut.Checked || chkColour.Checked || chkExtension.Checked || chkHighLights.Checked)
                {
                    //Calculate total with out discount
                    total = hairDresser() + service();
                    //conditional statment that calculate discount for number of visits
                    if (numVisit > 0 && numVisit <= 3)
                    {
                        total = total - (total * 0.00);
                    }
                    else if (numVisit >= 4 && numVisit <= 8)
                    {
                        total = total - (total * 0.05);
                    }
                    else if (numVisit >= 9 && numVisit <= 13)
                    {
                        total = total - (total * 0.10);
                    }
                    else if (numVisit > 14)
                    {
                        total = total - (total * 0.15);
                    }
                    //calculate discount for client type
                    total = total - (total * discountClient);
                    //Display Total Amount
                    lblTotal.Text = total + "";
                }
                else
                {
                    //Display a pop up message to notify the user to select at least one service
                    MessageBox.Show("Please Select At Least One Service!");
                }
            }
            else
            {
                //A pop up message to notify to enter a valid number of visit
                MessageBox.Show("Please enter a valid number of visit!");
                //Set cursor focut to txtVist textbox
                txtVist.Focus();
            }
            
        }
        //btnClear event handler
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVist.Clear();
            radJane.Checked = true;
            radStandard.Checked = true;
            chkCut.Checked = true;
            chkColour.Checked = false;
            chkExtension.Checked = false;
            chkHighLights.Checked = false;
            radJane.Focus();
        }
    }
}
