using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public static class StringUtils
    {
        public static string Simplify(this string s)
        {
            return s.Trim().ToLower();
        }
    }
}
