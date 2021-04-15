using GodEdictGen.Data;
using System.Collections.Generic;
using System.Linq;

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