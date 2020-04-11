using System.Collections.Generic;

namespace TextGen.Data
{
    public class EventGenerator
    {
        public readonly string edictName;
        public readonly long ID0, ID1;

        public EventGenerator(string edictName, long iD0, long iD1)
        {
            this.edictName = edictName;
            ID0 = iD0;
            ID1 = iD1;
        }

        public override string ToString()
        {
            return
$"## {edictName}\n" +
"country_event = { \n" +
"\n" +
$"  id = godEdict_toggle.{ID0}\n" +
"   hide_window = yes\n" +
"   is_triggered_only = yes\n" +
"\n" +
"     immediate = {\n" +
"            root = {\n" +
"                add_modifier = {\n" +
$"                    modifier = godEdict_{edictName}\n" +
"                    days = -1\n" +
"                }\n" +
$"                set_country_flag = flag_godEdict_{edictName}_on\n" +
"          }\n" +
"     }\n" +
"}\n" +
"\n" +
"country_event = {\n" +
$"  id = godEdict_toggle.{ID1}\n" +
"   hide_window = yes\n" +
"    is_triggered_only = yes\n" +
"\n" +
"   immediate = {\n" +
"       root = {\n" +
$"            remove_modifier = godEdict_{edictName}\n" +
$"            remove_country_flag = flag_godEdict_{edictName}_on \n" +
"        }\n" +
"   }\n" +
"}\n\n";
        }

        public static string Join(IEnumerable<EventGenerator> generators)
        {
            return
                "namespace = godEdict_toggle\n" + string.Join("", generators);
        }
    }
}