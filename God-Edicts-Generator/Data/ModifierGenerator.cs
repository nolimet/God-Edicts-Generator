using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GodEdictGen.Data
{
    public class ModifierGenerator
    {
        private static readonly NumberFormatInfo modiferValueFormat = new NumberFormatInfo()
        {
            NumberGroupSeparator = "",
            NumberDecimalSeparator = "."
        };

        private string modifierName;
        private string modifierValueString;
        private double? modifierValue;

        public string ModifierValue
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(modifierValueString))
                    return modifierValueString;
                if (modifierValue != null)
                {
                    return ModifierValueDouble.ToString(modiferValueFormat);
                }

                return string.Empty;
            }
        }

        public double ModifierValueDouble => (modifierValue ?? 00);


        public ModifierGenerator(string modifierName, string modifierValue)
        {
            this.modifierName = modifierName;
            this.modifierValueString = modifierValue;
        }

        public ModifierGenerator(string modifierName, double modifierValue)
        {
            this.modifierName = modifierName;
            this.modifierValue = modifierValue;
        }

        public static IReadOnlyList<ModifierGenerator> GenerateSet(string modifierFormat, double modifierValue, params string[] modifierNames)
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
            return $"\t{modifierName} = {ModifierValue}";
        }

        public static string Join(IEnumerable<ModifierGenerator> modifiers)
        {
            StringBuilder result = new StringBuilder();
            foreach (var modifier in modifiers)
            {
                result.AppendLine(modifier.ToString());
            }
           
            return result.ToString().TrimEnd('\n');
        }
    }
}