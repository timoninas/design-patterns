using System;
using System.Collections.Generic;

namespace Composite
{
    public interface Composite
    {
        string Name { get; }
        void AddComponent(Composite component);
        void ShowComponents();
    }

    public abstract class FileSystemObject: Composite
    {
        public string Name { get; }

        public FileSystemObject(string name)
        {
            this.Name = name;
        }

        public abstract void AddComponent(Composite component);
        public abstract void ShowComponents();
    }

    public class File: FileSystemObject
    {
        public File(string name) : base(name) { }

        public override void AddComponent(Composite component)
        {
            throw new Exception("You cannot add object in file");
        }

        public override void ShowComponents()
        {
            Console.WriteLine($"File > {this.Name}");
        }
    }

    public class Directory : FileSystemObject
    {
        public List<Composite> InnerObjects { get; private set; }

        public Directory(string name) : base(name)
        {
            this.InnerObjects = new List<Composite>();
        }

        public override void AddComponent(Composite component)
        {
            if (component != null)
            {
                this.InnerObjects.Add(component);
            }
        }

        public override void ShowComponents()
        {
            Console.WriteLine($"Dir  > {this.Name}");
            foreach (var item in this.InnerObjects)
            {
                item.ShowComponents();
            }
        }
    }
}
