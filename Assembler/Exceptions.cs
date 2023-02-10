using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblerOpgave
{
    public class AssemblyException : Exception
    {
        public AssemblyException(string message)
            : base(message)
        {
        }
        public AssemblyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
