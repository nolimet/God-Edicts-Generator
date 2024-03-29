﻿using System.Collections.Generic;

namespace GodEdictGen.Data
{
    public class LangueGenerator
    {
        public readonly StaticEdictGenerator edict;

        public LangueGenerator(StaticEdictGenerator edict)
        {
            this.edict = edict;
        }

        public override string ToString()
        {
            return
            $"#godEdict_{edict.name}\n" +
            $"godEdict_{edict.name}:0 \"£god_Edict_Icon£ {edict.nicename} \"\n" +
            $"edict_godEdict_{edict.name}_on:0 \"£god_Edict_Icon£ £trigger_no Enable {edict.nicename} \"\n" +
            $"edict_godEdict_{edict.name}_off:0 \"£god_Edict_Icon£ £trigger_yes Disable {edict.nicename} \"\n" +
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

        public static string GenerateFile(Edicts edicts, string langueName)
        {
            List<LangueGenerator> generators = new List<LangueGenerator>();
            for (int i = 0; i < edicts.Length; i++)
            {
                generators.Add(new LangueGenerator(edicts[i]));
            }

            return Join(generators, langueName);
        }
    }
}