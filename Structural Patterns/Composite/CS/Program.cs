using System;

namespace Composite
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Composite dirInit = new Directory("Initial dir");
            Composite dir1 = new Directory("Folder 1");
            Composite dir2 = new Directory("Folder 2");
            Composite dir3 = new Directory("Folder 3");
            Composite dir4 = new Directory("Folder 4");

            Composite file1 = new File("gol.obj");
            Composite file2 = new File("resume.docx");
            Composite file3 = new File("lab1.c");
            Composite file4 = new File("lab1.h");
            Composite file5 = new File("lab1.obj");

            dir4.AddComponent(file3);
            dir4.AddComponent(file4);
            dir4.AddComponent(file5);

            dir3.AddComponent(dir2);

            dir2.AddComponent(dir4);

            dir1.AddComponent(file2);

            dirInit.AddComponent(file1);
            dirInit.AddComponent(dir1);
            dirInit.AddComponent(dir3);

            dirInit.ShowComponents();

            // OUTPUT
            // Dir > Initial dir
            // File > gol.obj
            // Dir > Folder 1
            // File > resume.docx
            // Dir > Folder 3
            // Dir > Folder 2
            // Dir > Folder 4
            // File > lab1.c
            // File > lab1.h
            // File > lab1.obj
        }
    }
}
