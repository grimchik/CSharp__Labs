using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_maui;

    public static class Calculator
    {
        
        public static double toNumber(string str)
        {
            double number;
            if (!string.IsNullOrEmpty(str))
            {
                number = Convert.ToDouble(str);
            }
            else
            {
                number = 0.0;
            }
            return number;
        }
    }

