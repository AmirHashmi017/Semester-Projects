using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLinesLibrary
{
    public class Validations
    {
//This function checks whether the input is a valid number or not.
        public static bool CheckNumber(string enter)
        {
            for (int i = 0; i < enter.Length; i++)
            {
                if (i == 0 && enter[i] != '1' && enter[i] != '2' && enter[i] != '3' && enter[i] != '4' && enter[i] != '5' && enter[i] != '6' && enter[i] != '7' && enter[i] != '8' && enter[i] != '9' && enter[i] != '.')
                    return false;
                else if (i != 0 && enter[i] != '0' && enter[i] != '1' && enter[i] != '2' && enter[i] != '3' && enter[i] != '4' && enter[i] != '5' && enter[i] != '6' && enter[i] != '7' && enter[i] != '8' && enter[i] != '9' && enter[i] != '.')
                    return false;
            }
            return true;
        }
//This function checks that whether the provided input is a valid date or not.
        public static bool CheckValidDate(string date)
        {
            string dateFormat = "dd-MM-yyyy";
            if (DateTime.TryParseExact(date, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
//This function checks whether the provided input is a valid time or not.
        public static bool CheckValidTime(string time)
        {
            string timeFormat = "hh:mm tt";
            if (DateTime.TryParseExact(time, timeFormat, null, System.Globalization.DateTimeStyles.None, out DateTime parsedTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckInteger(string enter)
        {
            for (int i = 0; i < enter.Length; i++)
            {
                if (i == 0 && enter[i] != '1' && enter[i] != '2' && enter[i] != '3' && enter[i] != '4' && enter[i] != '5' && enter[i] != '6' && enter[i] != '7' && enter[i] != '8' && enter[i] != '9')
                    return false;
                else if (i != 0 && enter[i] != '0' && enter[i] != '1' && enter[i] != '2' && enter[i] != '3' && enter[i] != '4' && enter[i] != '5' && enter[i] != '6' && enter[i] != '7' && enter[i] != '8' && enter[i] != '9')
                    return false;
            }
            return true;
        }
//This function checks that whether the input contatins comma or colon or not.
        public static bool CheckCommaandColon(string enter)
        {
            for (int i = 0; i < enter.Length; i++)
            {
                if (enter[i] == ',' || enter[i] == ';')
                    return false;
            }
            return true;
        }
        public static bool CheckSemicolon(string enter)
        {
            for (int i = 0; i < enter.Length; i++)
            {
                if (enter[i] == ';')
                    return false;
            }
            return true;
        }
    }
}

