using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class CodeManipulator
    {
        public static string RemoveComments(string input)
        {
            return input.Split(new[] { "//" }, StringSplitOptions.None)[0].Trim().Replace("  ", String.Empty);
        }
    }
}
