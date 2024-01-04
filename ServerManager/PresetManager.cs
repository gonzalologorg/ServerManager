using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager
{
    public class PresetManager
    {
        public Preset[] presetList;
        public PresetManager() {
            Initialize();
        }

        void Initialize()
        {
            if (!Directory.Exists("./presets"))
                Directory.CreateDirectory("./presets");

            IEnumerable<String> presets = Directory.EnumerateFiles("./presets");
            presetList = new Preset[presets.Count()];

            for (int i = 0; i < presets.Count(); i++)
            {
                presetList[i] = new Preset(File.ReadAllLines("./" + presets.ElementAt(i)));
            }
        }

        public void addPreset(string Path, string Arguments, string Name)
        {
            File.WriteAllText("./presets/" + Name + ".preset", Path + "\n" + Arguments + "\n" + Name);
            Initialize();
        }

        public void removePreset(string Name)
        {
            try { File.Delete("./presets/" + Name + ".preset"); } catch { }
            Initialize();
        }
    }

    public class Preset
    {
        public string Path { get; set; }
        public string Arguments { get; set; }
        public string Name { get; set; }
        public Preset(string[] data)
        {
            Path = data[0]; Arguments = data[1]; Name = data[2];
        }
    }
}
