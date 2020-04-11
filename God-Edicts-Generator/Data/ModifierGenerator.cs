using System.Collections.Generic;
using System.Text;

namespace TextGen.Data
{
    public class ModifierGenerator
    {
        private string modifierName;
        private string modifierValue;

        public ModifierGenerator(string modifierName, string modifierValue)
        {
            this.modifierName = modifierName;
            this.modifierValue = modifierValue;
        }

        public ModifierGenerator(string modifierName, double modifierValue)
        {
            this.modifierName = modifierName;
            this.modifierValue = modifierValue.ToString();
        }

        public static ModifierGenerator[] GenerateSet(string modifierFormat, double modifierValue, params string[] modifierNames)
        {
            var sets = new ModifierGenerator[modifierNames.Length];
            for (int i = 0; i < modifierNames.Length; i++)
            {
                sets[i] = new ModifierGenerator(string.Format(modifierFormat, modifierNames[i]), modifierValue);
            }
            return sets;
        }

        public override string ToString()
        {
            return $"\t{modifierName} = {modifierValue}";
        }

        public static string Join(IEnumerable<ModifierGenerator> modifiers)
        {
            StringBuilder result = new StringBuilder();
            foreach (var modifier in modifiers)
            {
                result.AppendLine(modifier.ToString());
            }

            return result.ToString();
        }
    }
}