using System;
namespace NumberToWord
{
    public static class Helper
    {
        public static string GetWord(string _number)
        {
            string isNegative = "";
            if (string.IsNullOrEmpty(_number)) return string.Empty;
            if (_number.Contains("-"))
            {
                isNegative = "Minus ";
                _number = _number.Substring(1, _number.Length - 1);
            }
            if (_number == "0")
            {
                return "Zero Only";
            }
            else
            {
                return $"{isNegative}{ConvertToWords(_number)}";
            }
        }

        private static string GetOnes(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            switch (_Number)
            {

                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                default:return string.Empty;   
            }
        }

        private static string GetTens(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            switch (_Number)
            {
                case 10:
                   return "Ten";
                case 11:
                   return "Eleven";
                 
                case 12:
                   return "Twelve";
                 
                case 13:
                   return "Thirteen";
                 
                case 14:
                   return "Fourteen";
                 
                case 15:
                   return "Fifteen";
                 
                case 16:
                   return "Sixteen";
                 
                case 17:
                   return "Seventeen";
                 
                case 18:
                   return "Eighteen";
                 
                case 19:
                   return "Nineteen";
                 
                case 20:
                   return "Twenty";
                 
                case 30:
                   return "Thirty";
                 
                case 40:
                   return "Forty";
                 
                case 50:
                   return "Fifty";
                 
                case 60:
                   return "Sixty";
                 
                case 70:
                   return "Seventy";
                 
                case 80:
                   return "Eighty";
                 
                case 90:
                   return "Ninety";

                default:
                    {
                        if (_Number > 0)
                        {
                            return GetTens(Number.Substring(0, 1) + "0") + " " + GetOnes(Number.Substring(1));
                        }
                        return string.Empty;
                    }
                 
            }
        }

        private static string ConvertWholeNumber(string Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(Number));
                if (dblAmt > 0)
                {   
                    beginsZero = Number.StartsWith("0");
                    int numDigits = Number.Length;
                    int pos = 0; 
                    string place = "";  
                    switch (numDigits)
                    {
                        case 1:  
                            word = GetOnes(Number);
                            isDone = true;
                            break;
                        case 2:
                            word = GetTens(Number);
                            isDone = true;
                            break;
                        case 3:
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4:   
                        case 5:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;

                        case 6:
                        case 7:   
                        case 8:
                        case 9:
                            pos = (numDigits % 6) + 1;
                            place = " Lakh ";
                            break;
                        case 10:
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Crore  ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {  
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0" && Convert.ToInt32(Number.Substring(0, pos)) != 0)
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }
                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        private static string ConvertToWords(string numb)
        {
            string val = "", wholeNo = numb, andStr = "", pointStr = "";
            string endStr = "Only";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    string points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";   
                        endStr = " Paisa " + endStr;  
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = $"{ConvertWholeNumber(wholeNo).Trim()} {andStr}{pointStr}{endStr}";
            }
            catch { }
            return val;
        }
        private static string ConvertDecimals(string number)
        {
            string cd = "";
            for (int i = 0; i < number.Length; i++)
            {
                string digit = number[i].ToString();
                string engOne;
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = GetOnes(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }


    }
}
