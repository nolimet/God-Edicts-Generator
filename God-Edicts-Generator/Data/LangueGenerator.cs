using System.Collections.Generic;

namespace TextGen.Data
{
    public class LangueGenerator
    {
        public readonly string edictName;

        public LangueGenerator(string edictName)
        {
            this.edictName = edictName;
        }

        public override string ToString()
        {
            return
$"#godEdict_{edictName}\n" +
$"edict_godEdict_{edictName}_on:0 \"£trigger_no Enable {edictName.Replace("_", " ")} \"\n" +
$"edict_godEdict_{edictName}_off:0 \"£trigger_yes Disable {edictName.Replace("_", " ")} \"\n" +
"\n" +
$"edict_godEdict_{edictName}_on_desc:0 \"Enable {edictName.Replace("_", " ")} modifier \"\n" +
$"edict_godEdict_{edictName}_off_desc:0 \"Disable {edictName.Replace("_", " ")} modifier \"\n\n";
        }

        public static string Join(IEnumerable<LangueGenerator> generators, string langueName)
        {
            return
 $"l_{langueName}:\n\n" +
 string.Join("", generators);
        }
    }
}