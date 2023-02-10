using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public class Runner
    {

        private string fileLocation;
        private string outPath;

        public Runner(string fileLocation, string outPath)
        {
            this.fileLocation = fileLocation;
            this.outPath = outPath;
        }

        public string Run()
        {
            using FileStream reader = File.OpenRead(fileLocation);
            using StreamWriter writer = new StreamWriter(outPath, true);
            Translator translator = new Translator(Path.GetFileNameWithoutExtension(fileLocation));
            translator.ConvertToAssembly(new StreamReader(reader), writer);
            return outPath;
        }
    }
}
