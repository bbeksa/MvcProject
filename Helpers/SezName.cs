using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MvcProject.Helpers
{
    public class SezName : ValidationAttribute  
    {
        public List<string> Words = new List<String>();

        public SezName()
        {
            Words.Add("Spring");
            Words.Add("Summer");
        }

        public override bool IsValid(object value)
        {
            string strValue = value as string;
            foreach (var w in Words)
            {
                if (!string.IsNullOrEmpty(strValue))
                {
                    Console.WriteLine(w);
                    if (strValue.StartsWith(w))
                    {
                        if (int.TryParse(strValue.Substring(strValue.Length - 4), out _))
                            return true;
                    }
                } 
            }
            return false;
        }
    }
}