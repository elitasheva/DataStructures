namespace TraverseAndSaveDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            string path = @"C:\WINDOWS";
            var rootFolder = TraverseDirectories(path);

            Console.WriteLine(rootFolder.Size);
        }

        private static Folder TraverseDirectories(string path)
        {
            var queueFolders = new Queue<Folder>();
            DirectoryInfo directory = new DirectoryInfo(path);
            var rootFolder = new Folder(directory.Name, directory.FullName);
            queueFolders.Enqueue(rootFolder);

            while (queueFolders.Count > 0)
            {
                var currentFolder = queueFolders.Dequeue();
                var currentDir = new DirectoryInfo(currentFolder.FullPath);
                var filesInCurrentFolder = currentDir.GetFiles();
                foreach (var file in filesInCurrentFolder)
                {
                    var newFile = new File(file.Name, file.Length);
                    currentFolder.Files.Add(newFile);
                }

                var dirsInCurrentFolder = currentDir.GetDirectories();
                foreach (var dir in dirsInCurrentFolder)
                {
                    var newFolder = new Folder(dir.Name, dir.FullName);
                    currentFolder.Folders.Add(newFolder);

                    queueFolders.Enqueue(newFolder);
                }

            }

            return rootFolder;
        }
    }
}
