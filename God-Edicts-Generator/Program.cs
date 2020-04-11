using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GodEdictGen.Data;

namespace GodEdictGen
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GenerateEdictFile();
        }

        private static void GenerateEdictFile()
        {
            string outputDir = $"{Directory.GetCurrentDirectory()}/Output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Encoding encoding = new UTF8Encoding(false);
            Encoding encodingYML = new UTF8Encoding(true);
            var edicts = new Edicts();

            writeFileTXT(createEdictFile(), "edicts", @"common\edicts");
            writeFileTXT(createEventsFile(), "events", @"events");
            writeFileTXT(createStaticsFile(), "statics", @"common\static_modifiers");
            writeFileYML(createLangueFile("english"), "english", @"localisation");

            Console.Write($"PATH : {System.IO.Directory.GetCurrentDirectory()}");
            Console.ReadKey();

            string createEdictFile()
            {
                int k = 0;
                List<EdictToggleGenerator> edictElements = new List<EdictToggleGenerator>();
                for (int i = 0; i < edicts.Length; i++)
                {
                    edictElements.Add(new EdictToggleGenerator(edicts[i].name, k++, k++));
                }
                return string.Join("", edictElements);
            }

            string createEventsFile()
            {
                List<EventGenerator> eventElements = new List<EventGenerator>();
                int k = 0;
                for (int i = 0; i < edicts.Length; i++)
                {
                    eventElements.Add(new EventGenerator(edicts[i].name, k++, k++));
                }
                return EventGenerator.Join(eventElements);
            }

            string createLangueFile(string langueName)
            {
                List<LangueGenerator> generators = new List<LangueGenerator>();
                for (int i = 0; i < edicts.Length; i++)
                {
                    generators.Add(new LangueGenerator(edicts[i]));
                }

                return LangueGenerator.Join(generators, langueName);
            }

            string createStaticsFile()
            {
                return StaticEdictGenerator.Join(edicts.All);
            }

            void writeFileTXT(string value, string fileName, string folder = "")
            {
                folder = Path.Combine(outputDir, folder);
                Directory.CreateDirectory(folder);

                File.WriteAllText($"{folder}/godEdict_{fileName}.txt", value, encoding);
                Console.WriteLine(fileName.ToUpper());
                Console.Write(value);
                Console.WriteLine();
                Console.WriteLine();
            }

            void writeFileYML(string value, string fileName, string folder = "")
            {
                folder = Path.Combine(outputDir, folder);
                Directory.CreateDirectory(folder);

                File.WriteAllText($"{folder}/godEdict_l_{fileName}.yml", value, encodingYML);
                Console.WriteLine(fileName.ToUpper());
                Console.Write(value);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}