using System;
namespace NumberToWord
{
    public static class Extensions
    {
        
        public static string ToWord(this decimal number)
        {
            return Helper.GetWord(Convert.ToString(number));
        }
        public static string ToWord(this double number)
        {
            return Helper.GetWord(Convert.ToString(number));
        }
    }
}
