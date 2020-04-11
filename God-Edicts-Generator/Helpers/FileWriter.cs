using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodEdictGen.Helpers
{
    public static class FileWriter
    {
        static FileWriter()
        {
            outputDir = new DirectoryInfo($"{Directory.GetCurrentDirectory()}/Output");
            if (!outputDir.Exists)
                outputDir.Create();
        }

        static readonly DirectoryInfo outputDir;
        static readonly Encoding encoding = new UTF8Encoding(false);
        static readonly Encoding encodingYML = new UTF8Encoding(true);

        public static async Task WriteFileTXT(string value, string fileName, string folder = "")
        {
            DirectoryInfo directory = outputDir.CreateSubdirectory(folder);
            if (!directory.Exists)
                directory.Create();

            await WriteText(value, $"{directory.FullName}\\godEdict_{fileName}.txt", encoding);
        }

        public static async Task WriteFileYML(string value, string fileName, string folder = "")
        {
            DirectoryInfo directory = outputDir.CreateSubdirectory(folder);
            if (!directory.Exists)
                directory.Create();

            await WriteText(value, $"{directory.FullName}\\godEdict_l_{fileName}.yml", encodingYML);
        }

        private static async Task WriteText(string value, string fullPath, Encoding encoding)
        {
            FileInfo file = new FileInfo(fullPath);
            using (var fileStream = file.Exists? file.OpenWrite() : file.Create())
            {
                using (var writer = new StreamWriter(fileStream, encoding))
                {
                    try
                    {
                        await writer.WriteAsync(value);
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                        return;
                    }
                }
            }

            if (Program.DumpFileContent)
            {
                Console.WriteLine();
                Console.WriteLine(fullPath);
                Console.Write(value);
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine();
            }
        }

        private static async Task WriteBytes(byte[] data, string fullPath)
        {
            FileInfo file = new FileInfo(fullPath);

            using (var fileStream = file.Exists ? file.OpenWrite() : file.Create())
            {
                try
                {
                    await fileStream.WriteAsync(data, 0, data.Length);
                }
                catch(Exception e)
                {
                    Console.Write(e);
                    return;
                }
            }

            Console.WriteLine($"wrote {data.Length} bytes to {fullPath.Substring(outputDir.FullName.Length+1)}");
        }
    }
}
