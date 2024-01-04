using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager
{
    public class ScriptsManager
    {
        public string[] scripts;
        public ScriptsManager() {
            if (!Directory.Exists("./scripts"))
                Directory.CreateDirectory("./scripts");

            string[] scriptFiles = Directory.GetFiles("./scripts/");
            scripts = new string[scriptFiles.Count()];

            for (int i = 0; i < scriptFiles.Count(); i++)
            {
                string path = Path.GetFileName(scriptFiles[i]);
                string fileName = path.Substring(0, path.Length - 4);
                scripts[i] = fileName;
            }
        }
    }
}
