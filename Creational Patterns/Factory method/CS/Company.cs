using System;
namespace FactoryMethod
{
    abstract public class Company
    {
        public Company() { }

        abstract public Application CreateApplication();
    }

    public class MobileDeveloper: Company
    {
        public MobileDeveloper() { }

        public override Application CreateApplication()
        {
            MobileApp app = new MobileApp("Swift", "Wordz", MobileOS.iOS);
            return app;
        }
    }

    public class WebDeveloper : Company
    {
        public WebDeveloper() { }

        public override Application CreateApplication()
        {
            WebApp app = new WebApp("Safari", "Wordz");
            return app;
        }
    }

    abstract public class Application
    {
        public string Platform { get; private set; }
        public string ApplicationName { get; private set; }

        public Application(string platform, string name)
        {
            this.Platform = platform;
            this.ApplicationName = name;
        }

        abstract public void OpenApplication();
    }

    public enum MobileOS
    {
        iOS,
        Android
    }

    public class MobileApp: Application
    {
        public MobileOS typeOS { get; private set; }

        public MobileApp(string platform, string name, MobileOS typeOS): base(platform, name)
        {
            this.typeOS = typeOS;
        }

        public override void OpenApplication()
        {
            Console.WriteLine($"\nMobile app with {this.typeOS.ToString()}\n{this.Platform}\n{this.ApplicationName}");
        }
    }

    public class WebApp : Application
    {
        public MobileOS typeOS { get; private set; }

        public WebApp(string platform, string name) : base(platform, name) { }

        public override void OpenApplication()
        {
            Console.WriteLine($"\nWeb app opened! \n{this.Platform}\n{this.ApplicationName}");
        }
    }
}


