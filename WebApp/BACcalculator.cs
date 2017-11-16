using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApp
{
    public static class BACcalculator
    {
        //converts kilograms into pounds, needed for the result formula
        public static double convertWeightToPounds(double weight)
        {
            double result = 0;
            //1kg = 2.2lb
            result = weight * 2.2;

            return result;
        }

        //converts milliliters into ounces, needed for the result formula
        public static double convertAmountToOunces(double amount)
        {
            double result = 0;
            //1ml = 0.0338oz
            result = Math.Round(amount * 0.0338, 3);

            return result;
        }

        //Widmark’s basic formula for calculating a person’s estimated Blood Alcohol Content (BAC) at a particular time.
        public static double countBloodAlcoholContent(double weight, double amount, double time, double alcohol, double r, double servings)
        {
            double result = 0;

            result = Math.Round(((amount * servings * alcohol * 0.01 * 5.14) / (weight * r)) - (0.015 * time), 3);

            //0.015 is the average alcohol eliminatio rate.

            //5.14 is is a conversion factor of .823 x 100/16, wherein .823 is used to convert 
            //liquid ounces to ounces of weight, 100 is used to convert the final figure to a percentage, and 16 is used to convert pounds to ounces.

            return result;
        }

        //returns a message about person's welfare at the certain BAC level.
        public static String bacResultMessage(double result)
        {
            String message = null;

            StringBuilder msg = new StringBuilder();

            msg.Append("Your BAC level is " + result + "%.");

            if (Double.IsInfinity(result) || Double.IsNaN(result))
            {
                message = "There's a mistake in your data. Please correct it and try to calculate again.";
            }

            if (result <= 0)
            {
                result = 0;
                msg.Append("\nYou are perfectly fine.");

                message = msg.ToString();
            }

            if (result > 0 && result < 0.04)
            {
                msg.Append("\nYou may feel no loss of coordination, slight euphoria, and loss of shyness." +
                    " Depressant effects are not apparent. Mildly relaxed and maybe a little lightheaded.");
                message = msg.ToString();
            }

            if (result >= 0.04 && result < 0.06)
            {
                msg.Append("\nFeeling of well-being is apparent, relaxation, lower inhibitions," +
                    "sensation of warmth. Euphoria. Some minor impairment of judgment and memory, lowering of caution." +
                    "Your behavior may become exaggerated and emotions intensified (Good emotions are better, bad emotions are worse).");
                message = msg.ToString();
            }

            if (result >= 0.06 && result < 0.1)
            {
                msg.Append("\nSlight impairment of balance, speech, vision, reaction time, and hearing. Euphoria. " +
                    "Judgment and self-control are reduced, and caution, reason and memory are impaired, .08 is legally " +
                    "impaired and it is illegal to drive at this level. You will probably believe that you are functioning better " +
                    "than you really are.");
                message = msg.ToString();
            }

            if (result >= 0.1 && result < 0.13)
            {
                msg.Append("\nSignificant impairment of motor coordination and loss of good judgment. Your Speech " +
                    "may be slurred; balance, vision, reaction time and hearing will be impaired. Euphoria.");
                message = msg.ToString();
            }

            if (result >= 0.13 && result < 0.16)
            {
                msg.Append("\nGross motor impairment and lack of physical control. Blurred vision and major loss of " +
                    "balance. Euphoria is reduced and dysphoria (anxiety, restlessness) is beginning to appear. Judgment " +
                    "and perception are severely impaired.");
                message = msg.ToString();
            }

            if (result >= 0.16 && result < 0.2)
            {
                msg.Append("\nDysphoria predominates, nausea may appear. The drinker has the appearance of a ''sloppy drunk''.");
                message = msg.ToString();
            }

            if (result >= 0.2 && result < 0.25)
            {
                msg.Append("\nFelling dazed, confused or otherwise disoriented. May need help to stand or walk. If you " +
                    "injure yourself you may not feel the pain. Some people experience nausea and vomiting at this level. " +
                    "The gag reflex is impaired and you can choke if you do vomit. Blackouts are likely at this level so you " +
                    "may not remember what has happened.");
                message = msg.ToString();
            }

            if (result >= 0.25 && result < 0.3)
            {
                msg.Append("\nAll mental, physical and sensory functions are severely impaired. Increased risk of " +
                    "asphyxiation from choking on vomit and of seriously injuring yourself by falls or other accidents.");
                message = msg.ToString();
            }

            if (result >= 0.3 && result < 0.35)
            {
                msg.Append("\nYou have little comprehension of where you are. You may pass out suddenly and be difficult to awaken.");
                message = msg.ToString();
            }

            if (result >= 0.35 && result < 0.4)
            {
                msg.Append("\nVery high possibility of alcohol poisoning. Loss of consciousness.");
                message = msg.ToString();
            }

            if (result >= 0.4)
            {
                msg.Append("\nOnset of coma, and possible death due to respiratory arrest.");
                message = msg.ToString();
            }
            return message;
        }
    }
}