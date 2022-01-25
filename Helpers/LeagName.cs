using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MvcProject.Helpers
{
    public class LeagName : ValidationAttribute  
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public LeagName()
        {
            this.Minimum = 2;
            this.Maximum = int.MaxValue;
        }

        public override bool IsValid(object value)
        {
            string strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                if (Regex.IsMatch(strValue, @"^[A-Z]+$"))
                {
                    int len = strValue.Length;
                    return len >= this.Minimum && len <= this.Maximum;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}