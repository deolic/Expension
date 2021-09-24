namespace Expension.Utility
{
    public class StringConversion
    {
        internal static int ConvertToInt(string str)
        {
            int number;
            try
            {
                number = int.Parse(str);
            }
            catch (System.FormatException)
            {
                throw new System.Exception();
            }
            return number;
        }
    }
}
