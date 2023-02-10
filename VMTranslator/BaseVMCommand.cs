using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public abstract class BaseVMCommand
    {
        public abstract string ToAssembly();
    }
}
