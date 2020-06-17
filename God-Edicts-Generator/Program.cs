using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodEdictGen.Data;
using GodEdictGen.Helpers;

namespace GodEdictGen
{
    internal class Program
    {
        public static bool DumpFileContent = false;

        private static async Task Main(string[] args)
        {
            if (args != null)
            {
                DumpFileContent = args.Any(x => x == "dumpFileContent");
            }

            await Task.Delay(10);
            try
            {
                await GenerateEdictFile();
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
        }

        private static async Task GenerateEdictFile()
        {
            var edicts = new Edicts();

            Console.WriteLine($"PATH : {System.IO.Directory.GetCurrentDirectory()}");
            Console.WriteLine();

            await Task.Delay(100);
            await FileWriter.WriteFileTXT(EdictToggleGenerator.GenerateFile(edicts), "edicts", @"common\edicts");
            await FileWriter.WriteFileTXT(EventGenerator.GenerateFile(edicts), "events", @"events");
            await FileWriter.WriteFileTXT(StaticEdictGenerator.Join(edicts.All), "statics", @"common\static_modifiers");

            await FileWriter.WriteFileYML(LangueGenerator.GenerateFile(edicts, "english"), "english", @"localisation");

            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
            Console.WriteLine("\nExiting program");
            await Task.Delay(500);
        }
    }
}