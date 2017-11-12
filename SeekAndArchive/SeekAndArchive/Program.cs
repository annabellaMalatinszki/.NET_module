using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace SeekAndArchive
{
    class Program
    {
        static List<FileInfo> FoundFiles;
        static List<FileSystemWatcher> watchers;
        static List<DirectoryInfo> archiveDirectories;

        static void Main(string[] args)
        {
            string fileName = args[0];
            string directoryName = args[1];
            
            FoundFiles = new List<FileInfo>();
            watchers = new List<FileSystemWatcher>();
            archiveDirectories = new List<DirectoryInfo>();

            DirectoryInfo rootDir = new DirectoryInfo(directoryName);
            if (!rootDir.Exists)
            {
                Console.WriteLine("The specified directory does not exist.");
                return;
            }

            RecursiveSearch(FoundFiles, fileName, rootDir);

            Console.WriteLine("Found {0} files.", FoundFiles.Count());
            foreach (FileInfo file in FoundFiles)
            {
                Console.WriteLine("{0}", file.FullName);
            }

            foreach (FileInfo file in FoundFiles)
            {
                FileSystemWatcher newWatcher = new FileSystemWatcher(file.DirectoryName, file.Name);
                newWatcher.Changed += new FileSystemEventHandler(WatcherChanged);
                newWatcher.EnableRaisingEvents = true;
                watchers.Add(newWatcher);
            }

            for (int i = 0; i < FoundFiles.Count; i++)
            {
                archiveDirectories.Add(Directory.CreateDirectory("C:\\Users\\amala\\Desktop\\Archives\\archive" + i.ToString()));
                Console.WriteLine("created");
            }

            Console.ReadKey();
        }

        static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo file in currentDirectory.GetFiles())

            {
                if (new Regex("^" + Regex.Escape(fileName).Replace(@"\*", ".*").Replace(@"\?", ".") + "$", RegexOptions.IgnoreCase | RegexOptions.Singleline).IsMatch(file.Name))
                {
                    foundFiles.Add(file);
                }
            }
            
            foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                RecursiveSearch(foundFiles, fileName, dir);
            }
        }

        static void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} has been changed!", e.FullPath);
            FileSystemWatcher senderWatcher = (FileSystemWatcher)sender;
            int index = watchers.IndexOf(senderWatcher, 0);
            ArchiveFile(archiveDirectories[index], FoundFiles[index]);
        }

        static void ArchiveFile(DirectoryInfo archiveDirectory, FileInfo fileToArchive)
        {
            FileStream input = fileToArchive.OpenRead();
            FileStream output = File.Create(archiveDirectory.FullName + @"\" + fileToArchive.Name + ".gz");
            GZipStream Compressor = new GZipStream(output, CompressionMode.Compress);
            int b = input.ReadByte();
            while (b != -1)
            {
                Compressor.WriteByte((byte)b);
                b = input.ReadByte();
            }
            Compressor.Close();
            input.Close();
            output.Close();
        }
    }
}
