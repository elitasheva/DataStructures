namespace TraverseAndSaveDirectory
{
    using System.Collections.Generic;

    public class Folder
    {
        private long size;

        public Folder(string name, string fullPath)
        {
            this.Name = name;
            this.FullPath = fullPath;
            this.Files = new List<File>();
            this.Folders = new List<Folder>();
        }

        public string Name { get; private set; }

        public string FullPath { get; private set; }

        public IList<File> Files { get; private set; }

        public IList<Folder> Folders { get; private set; }

        public long Size
        {
            get
            {
                if (this.size != 0 || (this.Files.Count == 0 && this.Folders.Count == 0))
                {
                    return this.size;
                }

                foreach (var file in this.Files)
                {
                    this.size += file.Size;
                }

                foreach (var folder in this.Folders)
                {
                    this.size += folder.Size;
                }

                return this.size;
            }
        }
    }
}
