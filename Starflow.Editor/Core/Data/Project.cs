using System;
using Newtonsoft.Json;

namespace StarflowEditor.Core.Data
{
    public class Project
    {
        public string Name;
        public List<Resource>? Resources = new List<Resource>();
        public List<Folder> Folders = new List<Folder>();

        public class Resource
        {
            public string? Name { get; set; }
            public string? Path { get; set; }
        }

        public class Folder
        {
            public string? FolderPath { get; set; }
            public string? Name { get; set; }

            public Folder(string? folderPath, string? name)
            {
                FolderPath = folderPath;
                Name = name;
            }
        }
    }
}
