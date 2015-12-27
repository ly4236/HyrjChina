using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina
{
    public static class ConversionExtensions
    {
        #region int

        public static char ToHex(this int value)
        {
            if (value <= 9)
            {
                return (char)(value + 48);
            }
            return (char)((value - 10) + 97);
        }

        #endregion
    }
}
