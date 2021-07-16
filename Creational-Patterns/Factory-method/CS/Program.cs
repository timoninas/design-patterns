using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Company mobDev = new MobileDeveloper();
            Company webDev = new WebDeveloper();

            Application mobApp = mobDev.CreateApplication();
            Application webApp = webDev.CreateApplication();

            mobApp.OpenApplication();
            webApp.OpenApplication();


            // OUTPUT
            // Swift
            // Wordz

            // Web app opened!
            // Safari
            // Wordz
        }
    }
}
