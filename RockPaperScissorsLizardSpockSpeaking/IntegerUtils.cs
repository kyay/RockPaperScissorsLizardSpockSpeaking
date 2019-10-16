using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public static class IntegerUtils
    {
        public static int ForceParse(string strNumber)
        {
			try
			{
				return int.Parse(strNumber);
			}
			catch
			{
				return -1;
			}
        }
    }
}
