using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodEdictGen.Data;

namespace GodEdictGen.Helpers
{
    public static class ModifiersHelper
    {
        public static IReadOnlyList<ModifierGenerator> AddSet(this IReadOnlyList<ModifierGenerator> orignalList, string modifierFormat, double modifierValue, params string[] modifierNames)
        {
            return orignalList.Concat(ModifierGenerator.GenerateSet(modifierFormat, modifierValue, modifierNames)).ToArray();
        }
    }
}
