using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackToHack
{
    public class Runner
    {
        private string inputPath;
        private string outputPath;
        private string jackOS = "./JackOS";
        public Runner(string inputPath, string outputPath)
        {
            this.inputPath = inputPath;
            this.outputPath = outputPath;
        }

    }
}
