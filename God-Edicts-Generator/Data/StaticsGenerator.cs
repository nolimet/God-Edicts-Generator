using System.Collections.Generic;
using System.Text;

namespace TextGen.Data
{
    public class StaticsGenerator
    {
        public readonly string name;
        public readonly IEnumerable<ModifierGenerator> modifiers;

        public StaticsGenerator(string edictName, ModifierGenerator[] modifiers)
        {
            this.name = edictName;
            this.modifiers = modifiers;
        }

        public override string ToString()
        {
            return $"godEdict_God_Mode = {{\n{ModifierGenerator.Join(modifiers)}\n}}\n";
        }

        public static string Join(IEnumerable<StaticsGenerator> edicts)
        {
            StringBuilder result = new StringBuilder();
            foreach (var edict in edicts)
            {
                result.AppendLine(edict.ToString());
            }
            return result.ToString();
        }
    }
}