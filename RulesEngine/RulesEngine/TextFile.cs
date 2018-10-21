using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RulesEngine
{
    public class TextFile : IDisposable
    {
        StreamWriter file = null;

        public TextFile()
        {
            string outPath = Program.GetApplicationPath() + "\\" + Properties.Resources.OutputText;
            file = new System.IO.StreamWriter(outPath, true);
        }
        public void WriteLine(string source)
        {
            if (string.IsNullOrEmpty(Program.GetApplicationPath()) && file != null)
                return;
            
            file.WriteLine(source);
        }

        public void Dispose(bool result)
        {
            if (result)
                Dispose();
        }

        public void Dispose()
        {
            if (file != null)
            {
                file.Close();
                file.Dispose();
                file = null;
            }
        }
    }
}
