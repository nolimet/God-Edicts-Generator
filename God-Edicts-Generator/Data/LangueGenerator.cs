using System.Collections.Generic;

namespace TextGen.Data
{
    public class LangueGenerator
    {
        public readonly StaticsGenerator edict;

        public LangueGenerator(StaticsGenerator edict)
        {
            this.edict = edict;
        }

        public override string ToString()
        {
            return
            $"#godEdict_{edict.name}\n" +
            $"godEdict_{edict.name}:0 \"£god_Edict_Icon {edict.nicename} \"\n" +
            $"edict_godEdict_{edict.name}_on:0 \"£trigger_no Enable {edict.nicename} \"\n" +
            $"edict_godEdict_{edict.name}_off:0 \"£trigger_yes Disable {edict.nicename} \"\n" +
            "\n" +
            $"edict_godEdict_{edict.name}_on_desc:0 \"Enable {edict.nicename} modifier \"\n" +
            $"edict_godEdict_{edict.name}_off_desc:0 \"Disable {edict.nicename} modifier \"\n\n";
        }

        public static string Join(IEnumerable<LangueGenerator> generators, string langueName)
        {
            return
 $"l_{langueName}:\n\n" +
 string.Join("", generators);
        }
    }
}