using System;

namespace TemplateMethod
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            FullScreenForm form1 = new FullScreenForm("Form1", "1024x780");
            form1.LoadScreen();
            Console.WriteLine();
            Console.WriteLine(form1.Log);
        }

        // OUTPUT
        // Form1 -> 1024x780
        // Form1 :- LoadForm
        // Form1 :- FormDidLoad
        // Form1 :- FormWillAppear
        // Form1 :- FormDidAppear
    }
}
