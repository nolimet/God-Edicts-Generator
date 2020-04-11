namespace TextGen.Data
{
    public struct EdictGenerator
    {
        public readonly string edictName;
        public readonly int edictNumber0, edictNumber1;

        public EdictGenerator(string editName, int edictNumber0, int edictNumber1)
        {
            this.edictName = editName;
            this.edictNumber0 = edictNumber0;
            this.edictNumber1 = edictNumber1;
        }

        public override string ToString()
        {
            return
   $"## {edictName}\n" +
   $"godEdict_{edictName}_on = " + "{\n" +
    "	length = 0\n" +
    "	resources = {\n" +
    "		category = edicts\n" +
    "		cost = { influence = 0 }\n" +
    "	}\n" +
    "\n" +
    "	potential = {\n" +
    "			NOT = { has_country_flag = flag_godEdict_" + edictName + "_on }\n" +
    "		}\n" +
    "	\n" +
    "	effect = " +
    "		{\n" +
    "			country_event = { id = godEdict_toggle." + edictNumber0 + " days = 0}\n" +
    "		}\n" +
    "	\n" +
    "	allow = {}\n" +
    "	\n" +
    "	ai_weight = {\n" +
    "			weight = 0\n" +
    "		}\n" +
    "}\n" +
    "\n" +
   $"godEdict_{edictName}_off = " + "{\n" +
    "	length = 0\n" +
    "	\n" +
    "	resources = {\n" +
    "		category = edicts\n" +
    "		cost = { influence = 0 }\n" +
    "	}\n" +
    "	potential = {\n" +
    "			has_country_flag = flag_godEdict_" + edictName + "_on \n" +
    "	}\n" +
    "	\n" +
    "	effect = {\n" +
    "		country_event = { id = godEdict_toggle." + edictNumber1 + " days = 0}\n" +
    "	}\n" +
    "	\n" +
    "	allow = {}\n" +
    "	\n" +
    "	ai_weight = { weight = 0 }\n" +
    "}\n\n";
        }
    }
}