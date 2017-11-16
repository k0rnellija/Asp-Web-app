using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private double inputWeight = 0;
        private double convertedWeight = 0;
        private double convertedAmount = 0;
        private double inputTime = 0;
        private double inputAlcohol = 0;
        private int inputServings = 0;
        private double resultBAC = 0;
        private double r = 0;       //gender coefficient for the formula
        private String note = null;
        private double inputAmount;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void Btn_save_Click(object sender, EventArgs e)
        {
            Double.TryParse(txt_weight.Text, out inputWeight);
            if (inputWeight < 0 || inputWeight > 500)
            {
                MsgBox("Your weight can't be negative, please correct it.");
                
            }
            else { convertedWeight = BACcalculator.convertWeightToPounds(inputWeight); }

            Double.TryParse(txt_time.Text, out inputTime);
            if (inputTime < 0 || inputTime > 24)
            {
                MsgBox("Time input is wrong, please correct it");
                
            }

            Double.TryParse(txt_alcohol.Text, out inputAlcohol);
            if (inputAlcohol < 0 || inputAlcohol > 100)
            {
                MsgBox("Percentage of alcohol can't be less tha 0% or more than 100%, please correct it");
                
            }

            Double.TryParse(txt_amount.Text, out inputAmount);
            if (inputAmount < 0)
            {
                MsgBox("Consumed amount of beverage can't be negative, please correct it");
                
            }
            else { convertedAmount = BACcalculator.convertAmountToOunces(inputAmount); }

            int.TryParse(txt_servings.Text, out inputServings);
            if (inputServings < 0)
            {
                MsgBox("Total number of servings can't be negative, please correct it");
               
            }

            if (DropDownListGender.SelectedIndex == -1)
            {
                MsgBox("You have to select your gender");
               
            }
            else if (DropDownListGender.SelectedItem.ToString() == "Female")
            {
                r = 0.66;
            }

            else if (DropDownListGender.SelectedItem.ToString() == "Male")
            {
                r = 0.73;
            }

            if (string.IsNullOrEmpty(txt_weight.Text) || string.IsNullOrEmpty(txt_time.Text) || string.IsNullOrEmpty(txt_amount.Text)
                || string.IsNullOrEmpty(txt_servings.Text) || string.IsNullOrEmpty(txt_servings.Text) || string.IsNullOrEmpty(DropDownListGender.ToString()))
            {
                MsgBox("All fields need to be full!");
                
            }
            else
            {
                MsgBox("All data is successfully saved, you can now calculate your BAC");
                
            }

        }

        protected void Btn_calculate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_weight.Text) || string.IsNullOrEmpty(txt_time.Text) || string.IsNullOrEmpty(txt_amount.Text)
                || string.IsNullOrEmpty(txt_servings.Text) || string.IsNullOrEmpty(txt_servings.Text) || string.IsNullOrEmpty(DropDownListGender.ToString()))
            {
                MsgBox("All fields need to be full!");

            }
            else
            {
                 resultBAC = BACcalculator.countBloodAlcoholContent(convertedWeight, convertedAmount, inputTime,
                    inputAlcohol, r, inputServings);
                note = BACcalculator.bacResultMessage(resultBAC);
                //Console.Write(note);
                MsgBox(note);

            }
        }

        public void MsgBox(String msg)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('" + msg + "')", true);
            
        }
    }
}