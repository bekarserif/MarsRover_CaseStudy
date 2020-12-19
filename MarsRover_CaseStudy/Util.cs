using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_CaseStudy
{
    public class Util
    {
        /// <summary>
        /// Returns true if given string is castable to Integer
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Boolean</returns>
        public static Boolean IsInteger(String str)
        {
            if (str == null)
            {
                return false;
            }
            int length = str.Length;
            if (length == 0)
            {
                return false;
            }
            int i = 0;
            if (str[0] == '-')
            {
                if (length == 1)
                {
                    return false;
                }
                i = 1;
            }
            for (; i < length; i++)
            {
                char c = str[i];
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns true if given string is castable to Directions enum inside Rover class
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Boolean</returns>
        public static Boolean IsValidDirection(String str)
        {
            if (str == null)
            {
                return false;
            }
            if (str.Length == 0 || str.Length > 1)
            {
                return false;
            }
            foreach (var direction in str)
            {
                if (direction == 'N' || direction == 'E' || direction == 'S' || direction == 'W')
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
