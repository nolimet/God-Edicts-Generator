using System.Collections.Generic;
using System.Text;

namespace GodEdictGen.Data
{
    public class StaticEdictGenerator
    {
        public readonly string name;
        public readonly string nicename;
        public readonly IReadOnlyList<ModifierGenerator> modifiers;

        public StaticEdictGenerator(string name, IReadOnlyList<ModifierGenerator> modifiers)
        {
            this.name = name;
            this.modifiers = modifiers;
            nicename = name.Replace('_', ' ');
        }

        public StaticEdictGenerator(string name, string nicename, IReadOnlyList<ModifierGenerator> modifiers)
        {
            this.name = name;
            this.modifiers = modifiers;
            this.nicename = nicename;
        }

        public override string ToString()
        {
            return $"godEdict_{name} = {{\n{ModifierGenerator.Join(modifiers)}\n}}\n";
        }

        public static string Join(IEnumerable<StaticEdictGenerator> edicts)
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